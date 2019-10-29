using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Infrastructure.Models
{
    public class Upload_Infra
    {
        public int? Id { get; set; }
        public int? Comment_InfraId { get; set; }
        public byte[] File { get; set; }
    }

}
