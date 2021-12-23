using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //validation er jonno. Annotation msg gula dekhanor jonno lagbe.
using System.Linq;
using System.Web;

namespace Lec_03.Models.Entities
{
    public class Student //Student table er column specification will be here
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please put your name")] //eta deowa mane ei proprty ta lagbei. Name property
        [StringLength(10, ErrorMessage = "Name should not exceed 10 char")]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Gender { get; set; }
        public double Cgpa { get; set; }
    }
}