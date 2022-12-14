//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Part1WindowsFormApp.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="stringStatistics", Namespace="http://schemas.datacontract.org/2004/07/Homework1Part1")]
    [System.SerializableAttribute()]
    public partial class stringStatistics : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DigitCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LowercaseCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UppercaseCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VowelCountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DigitCount {
            get {
                return this.DigitCountField;
            }
            set {
                if ((this.DigitCountField.Equals(value) != true)) {
                    this.DigitCountField = value;
                    this.RaisePropertyChanged("DigitCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LowercaseCount {
            get {
                return this.LowercaseCountField;
            }
            set {
                if ((this.LowercaseCountField.Equals(value) != true)) {
                    this.LowercaseCountField = value;
                    this.RaisePropertyChanged("LowercaseCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UppercaseCount {
            get {
                return this.UppercaseCountField;
            }
            set {
                if ((this.UppercaseCountField.Equals(value) != true)) {
                    this.UppercaseCountField = value;
                    this.RaisePropertyChanged("UppercaseCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VowelCount {
            get {
                return this.VowelCountField;
            }
            set {
                if ((this.VowelCountField.Equals(value) != true)) {
                    this.VowelCountField = value;
                    this.RaisePropertyChanged("VowelCount");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/reverse", ReplyAction="http://tempuri.org/IService1/reverseResponse")]
        string reverse(string str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/reverse", ReplyAction="http://tempuri.org/IService1/reverseResponse")]
        System.Threading.Tasks.Task<string> reverseAsync(string str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/analyzeStr", ReplyAction="http://tempuri.org/IService1/analyzeStrResponse")]
        Part1WindowsFormApp.ServiceReference1.stringStatistics analyzeStr(string str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/analyzeStr", ReplyAction="http://tempuri.org/IService1/analyzeStrResponse")]
        System.Threading.Tasks.Task<Part1WindowsFormApp.ServiceReference1.stringStatistics> analyzeStrAsync(string str);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Part1WindowsFormApp.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Part1WindowsFormApp.ServiceReference1.IService1>, Part1WindowsFormApp.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string reverse(string str) {
            return base.Channel.reverse(str);
        }
        
        public System.Threading.Tasks.Task<string> reverseAsync(string str) {
            return base.Channel.reverseAsync(str);
        }
        
        public Part1WindowsFormApp.ServiceReference1.stringStatistics analyzeStr(string str) {
            return base.Channel.analyzeStr(str);
        }
        
        public System.Threading.Tasks.Task<Part1WindowsFormApp.ServiceReference1.stringStatistics> analyzeStrAsync(string str) {
            return base.Channel.analyzeStrAsync(str);
        }
    }
}
