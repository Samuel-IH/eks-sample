/*
 * Title
 *
 * Title
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Org.OpenAPITools.Converters;

namespace Org.OpenAPITools.Models
{ 
        /// <summary>
        /// Gets or Sets SpinEnum
        /// </summary>
        [TypeConverter(typeof(CustomEnumConverter<SpinEnum>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum SpinEnum
        {
            
            /// <summary>
            /// Enum GRAPEFRUITEnum for GRAPEFRUIT
            /// </summary>
            [EnumMember(Value = "GRAPEFRUIT")]
            GRAPEFRUITEnum = 1,
            
            /// <summary>
            /// Enum LEMONEnum for LEMON
            /// </summary>
            [EnumMember(Value = "LEMON")]
            LEMONEnum = 2,
            
            /// <summary>
            /// Enum LIMEEnum for LIME
            /// </summary>
            [EnumMember(Value = "LIME")]
            LIMEEnum = 3,
            
            /// <summary>
            /// Enum ORANGEEnum for ORANGE
            /// </summary>
            [EnumMember(Value = "ORANGE")]
            ORANGEEnum = 4
        }
}
