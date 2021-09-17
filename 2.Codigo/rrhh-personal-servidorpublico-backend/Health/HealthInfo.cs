using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minedu.rrhh.personal.servidorpublico.backend.Health
{
	public class HealthInfo
	{
		public string Key { get; set; }
		public string Description { get; set; }
		public TimeSpan Duration { get; set; }
		public string Status { get; set; }
		public string Error { get; set; }
	}
}
