﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inmobiliaria.Domain.Shared.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Errores {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errores() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Inmobiliaria.Domain.Shared.Resources.Errores", typeof(Errores).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Recurso {0} no encontrado.
        /// </summary>
        public static string ResourceNotFound {
            get {
                return ResourceManager.GetString("ResourceNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor no puede ser nulo.
        /// </summary>
        public static string ValueCannotBeNull {
            get {
                return ResourceManager.GetString("ValueCannotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor debe ser mayor o igual a {0}.
        /// </summary>
        public static string ValueMustBeGreaterOrEqualTo {
            get {
                return ResourceManager.GetString("ValueMustBeGreaterOrEqualTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor debe ser mayor que {0}.
        /// </summary>
        public static string ValueMustBeGreaterThan {
            get {
                return ResourceManager.GetString("ValueMustBeGreaterThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor debe ser menor o igual a {0}.
        /// </summary>
        public static string ValueMustBeLessOrEqualTo {
            get {
                return ResourceManager.GetString("ValueMustBeLessOrEqualTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor debe ser menor que {0}.
        /// </summary>
        public static string ValueMustBeLessThan {
            get {
                return ResourceManager.GetString("ValueMustBeLessThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor no debe estar vacío.
        /// </summary>
        public static string ValueMustNotBeEmpty {
            get {
                return ResourceManager.GetString("ValueMustNotBeEmpty", resourceCulture);
            }
        }
    }
}