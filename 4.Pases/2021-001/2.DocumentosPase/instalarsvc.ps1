param(
    [Parameter(Mandatory=$True, Position=0, ValueFromPipeline=$false)]
    [System.String]
    $appname,

    [Parameter(Mandatory=$True, Position=1, ValueFromPipeline=$false)]
    [System.Int32]
    $appport,
	
    [Parameter(Mandatory=$True, Position=2, ValueFromPipeline=$false)]
    [System.String]
    $path,
	
    [Parameter(Mandatory=$True, Position=3, ValueFromPipeline=$false)]
    [System.Boolean]
    $alwaysRunning
)

$hostIP = (
    Get-NetIPConfiguration |
    Where-Object {
        $_.IPv4DefaultGateway -ne $null -and
        $_.NetAdapter.Status -ne "Disconnected"
    }
).IPv4Address.IPAddress

if( ![System.IO.Directory]::Exists( $path ) )
{
    New-Item -ItemType directory -Path $path
}

if( -Not (Test-Path IIS:\Sites\$appname))
{
	Write-Output "Creando el website $appname"
	New-Website -Name $appname -ApplicationPool $appname -Force -IPAddress $hostIP -Port $appport -HostHeader "" -PhysicalPath $path
	New-WebBinding -Name $appname -IPAddress "*" -Port $appport -HostHeader $Env:Computername.ToLower()
}

if( -Not (Test-Path IIS:\AppPools\$appname))
{
	Write-Output "Creando el pool $appname de la aplicacion"
	New-WebAppPool -Name $appname -Force
	Set-ItemProperty IIS:\AppPools\$appname managedRuntimeVersion ""
	if ($alwaysRunning -eq $true)
	{
		Set-ItemProperty IIS:\AppPools\$appname startMode "AlwaysRunning"
		Set-ItemProperty IIS:\AppPools\$appname processModel.idleTimeout "0"
		Set-ItemProperty IIS:\Sites\$appname applicationDefaults.preloadEnabled True
	}
}

Write-Output "La aplicacion web se creo exitosamente"
