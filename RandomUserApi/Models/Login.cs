using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandomUserApi.Models
{


    [Table("login")] 
    public class Login
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("uuid")]
        public Guid Uuid { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("salt")]
        public string Salt { get; set; }

        [Column("md5")]
        public string Md5 { get; set; }

        [Column("sha1")]
        public string Sha1 { get; set; }

        [Column("sha256")]
        public string Sha256 { get; set; }
    }


}
