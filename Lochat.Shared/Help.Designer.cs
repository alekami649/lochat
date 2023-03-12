﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lochat.Shared {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Help {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Help() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Lochat.Shared.Help", typeof(Help).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
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
        ///   Ищет локализованную строку, похожую на Command to initialize current server. Available options:
        ///&quot;lochat init&quot; (0 arguments) - initializing Lochat server in &quot;C:\Shared\Lochat&quot; folder.
        ///&quot;lochat init (folder_path)&quot; (1 argument) - initializing Lochat server in specified folder path..
        /// </summary>
        public static string InitCommand {
            get {
                return ResourceManager.GetString("InitCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Command to connect the server&apos;s (0) chat. Available options:
        ///&quot;lochat join&quot; - no arguments, connecting to the default server ({0}).
        ///&quot;lochat join (server&apos;s_name)&quot; (1 argument) - connecting to specified server..
        /// </summary>
        public static string JoinCommand {
            get {
                return ResourceManager.GetString("JoinCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Help for Lochat:
        ///&quot;lochat join&quot; - connecting to chat.
        ///&quot;lochat send&quot; - sending message.
        ///&quot;lochat help&quot; - help for any command.
        ///&quot;lochat init&quot; - initializing Lochat server..
        /// </summary>
        public static string MainHelp {
            get {
                return ResourceManager.GetString("MainHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Command to send message to the server ({0})&apos;s chat. Available options:
        ///&quot;lochat send (message_text)&quot; (1 arguments) - sending specified message to default server ({0}).
        ///&quot;lochat send (message_text) (server_name)&quot; (2 arguments) - sending specified message to specified server..
        /// </summary>
        public static string SendCommand {
            get {
                return ResourceManager.GetString("SendCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Command to configurate your settings. Available options:
        ///&quot;lochat settings (setting_name)&quot; (1 argument) - Shows value of specified setting.
        ///&quot;lochat settings (setting_name) (value_to_set)&quot; (2 arguments) - Sets specified value for specified setting.
        ///Available setting names (can use any with &quot;--&quot; prefix): name, username, default_server, date_format, folder_path..
        /// </summary>
        public static string SettingsCommand {
            get {
                return ResourceManager.GetString("SettingsCommand", resourceCulture);
            }
        }
    }
}
