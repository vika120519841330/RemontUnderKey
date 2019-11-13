using System;

namespace RemontUnderKey.Infrastructure.Models
{
    public class UploadPhoto_Infra
    {
        public int? Id { get; set; }
        public int Repareobject_InfraId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

    }
}