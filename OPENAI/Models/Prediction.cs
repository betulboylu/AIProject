using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Models
{
    /// <summary>
    /// Prodection Model
    /// Contains FileUpload and Text of user
    /// </summary>
    public class Prediction
    {
        [Required(ErrorMessage ="Please type a text to predict")]
        public string Text { get; set; }

        [Required(ErrorMessage ="Please pick a CSV file to train the model")]
        //[FileExtensions(Extensions = "text/csv", ErrorMessage = "Only CSV files are allowed")]
        public IFormFile File { get; set; }
    }
}
