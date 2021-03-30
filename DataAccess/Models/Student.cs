﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.DataAccess.Models
{
    [Table("Student")]
    public class Student
    {

        [Key] public int Id { get; set; }
        
        [Comment("First name of the user"), MaxLength(10), Required]
        public string Name { get; set; }

        [Comment("Second name of the user"), MaxLength(10)]
        public string SecondName { get; set; }
        [Comment("Base64 picture of the user, can be nullable")]
        public string Picture { get; set; }

        [Comment("Short description of the user, cant be nullable"), Required, MaxLength(250)]
        public string About { get; set; }

        [Comment("Rank of the user, cant be nullable"), Required]
        public Rank Rank { get; set; }

        [Comment("Group of the user, cant be nullable"),  Required]
        public Group Group { get; set; }

    }
}