using System;

namespace RemontUnderKey.Domain.Models
{
    public class UploadPhoto_Domain
    {
        public int? Id { get; set; }
        public int Repareobject_DomainId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

    }
}