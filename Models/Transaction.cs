using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalBudget.Models
{
    public class Transaction
    {
        //a unique id for each transaction
        [Required]
        public string Id { get; }
        
        //a timestamp to save the time a transaction take place (simplified)
        public DateTime Date { get; set; }
        
        //a simple text to describe the subject of the transaction
        [Required]
        [StringLength(100, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }
        
        //the amount of the transaction
        // [Range(Double.NegativeInfinity, -0.01f)]
        [DataType(DataType.Currency)]
        [NotZeroValidator]
        public decimal Amount { get; set; }

        
        //optional parameter to give the transaction a label
        public string Label { get; set; }
        
        /// <summary>
        /// The constructor of the Transaction class
        /// gives a new transaction a guid for easy identification and database usage
        /// </summary>
        public Transaction()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.Now;
        }


        private class NotZeroValidator : ValidationAttribute
        {
            /// <summary>
            /// Designed for dropdowns to ensure that a selection is valid and not the dummy "SELECT" entry
            /// </summary>
            public NotZeroValidator() : base("Please enter an amount e.g. 1.32")
            {

            }

            /// <param name="value">The integer value of the selection</param>
            /// <param name="validationContext">The Validation Context</param>
            /// <returns>True if value is not null</returns>
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                //checks if amount entered is a decimal and if the amount is != null and 0
                if (value != null && decimal.TryParse(value.ToString(), out var i))
                {
                    return i is > 0 or < 0 ? ValidationResult.Success : new ValidationResult("Please enter an amount other than 0");
                }

                return new ValidationResult(ErrorMessage);
                
            }
        }
    }
}