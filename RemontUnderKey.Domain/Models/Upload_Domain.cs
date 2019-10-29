using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemontUnderKey.Domain.Models
{
    public class Upload_Domain
    {
        public int? Id { get; set; }
        public int? Comment_DomainId { get; set; }
        public byte[] File { get; set; }
    }
}
