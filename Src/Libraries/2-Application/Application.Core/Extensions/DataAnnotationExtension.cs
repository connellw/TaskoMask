﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TaskoMask.Application.Core.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class DataAnnotationExtension
    {


        /// <summary>
        /// 
        /// </summary>
        public static bool Validate<T>(this T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }



        /// <summary>
        /// 
        /// </summary>
        public static object GetDisplayName<T>(this T obj) where T : class
        {
            return typeof(T).CustomAttributes.Any() ?
                typeof(T).CustomAttributes.First().ConstructorArguments.First().Value :
                nameof(T);
        }


    }
}