﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.225.
// 
#pragma warning disable 1591

namespace nJupiter.Tests.MessagingWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MessagingWebServiceSoap", Namespace="urn:njupiter:messaging:webservice")]
    public partial class MessagingWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback PublishOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddMessageConsumerOperationCompleted;
        
        private System.Threading.SendOrPostCallback NotifyOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MessagingWebService() {
            this.Url = "http://localhost/nJupiter/nJupiter.Messaging.WebService/Web/MessagingWebService.a" +
                "smx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event PublishCompletedEventHandler PublishCompleted;
        
        /// <remarks/>
        public event AddMessageConsumerCompletedEventHandler AddMessageConsumerCompleted;
        
        /// <remarks/>
        public event NotifyCompletedEventHandler NotifyCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:njupiter:messaging:webservice/Publish", RequestNamespace="urn:njupiter:messaging:webservice", ResponseNamespace="urn:njupiter:messaging:webservice", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Publish(Message message) {
            this.Invoke("Publish", new object[] {
                        message});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPublish(Message message, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Publish", new object[] {
                        message}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndPublish(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        public void PublishAsync(Message message) {
            this.PublishAsync(message, null);
        }
        
        /// <remarks/>
        public void PublishAsync(Message message, object userState) {
            if ((this.PublishOperationCompleted == null)) {
                this.PublishOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPublishOperationCompleted);
            }
            this.InvokeAsync("Publish", new object[] {
                        message}, this.PublishOperationCompleted, userState);
        }
        
        private void OnPublishOperationCompleted(object arg) {
            if ((this.PublishCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PublishCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:njupiter:messaging:webservice/AddMessageConsumer", RequestNamespace="urn:njupiter:messaging:webservice", ResponseNamespace="urn:njupiter:messaging:webservice", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddMessageConsumer(MessageConsumer messageConsumer) {
            this.Invoke("AddMessageConsumer", new object[] {
                        messageConsumer});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddMessageConsumer(MessageConsumer messageConsumer, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddMessageConsumer", new object[] {
                        messageConsumer}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndAddMessageConsumer(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        public void AddMessageConsumerAsync(MessageConsumer messageConsumer) {
            this.AddMessageConsumerAsync(messageConsumer, null);
        }
        
        /// <remarks/>
        public void AddMessageConsumerAsync(MessageConsumer messageConsumer, object userState) {
            if ((this.AddMessageConsumerOperationCompleted == null)) {
                this.AddMessageConsumerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddMessageConsumerOperationCompleted);
            }
            this.InvokeAsync("AddMessageConsumer", new object[] {
                        messageConsumer}, this.AddMessageConsumerOperationCompleted, userState);
        }
        
        private void OnAddMessageConsumerOperationCompleted(object arg) {
            if ((this.AddMessageConsumerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddMessageConsumerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:njupiter:messaging:webservice/Notify", RequestNamespace="urn:njupiter:messaging:webservice", ResponseNamespace="urn:njupiter:messaging:webservice", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Notify(Message message) {
            this.Invoke("Notify", new object[] {
                        message});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginNotify(Message message, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Notify", new object[] {
                        message}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndNotify(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        public void NotifyAsync(Message message) {
            this.NotifyAsync(message, null);
        }
        
        /// <remarks/>
        public void NotifyAsync(Message message, object userState) {
            if ((this.NotifyOperationCompleted == null)) {
                this.NotifyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNotifyOperationCompleted);
            }
            this.InvokeAsync("Notify", new object[] {
                        message}, this.NotifyOperationCompleted, userState);
        }
        
        private void OnNotifyOperationCompleted(object arg) {
            if ((this.NotifyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NotifyCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:nJupiter:Messaging:Message")]
    public partial class Message {
        
        private MessageDestination messagedestinationField;
        
        private long idField;
        
        private System.DateTime createdField;
        
        private System.DateTime startpublishField;
        
        private System.DateTime stoppublishField;
        
        private string dataField;
        
        private int intervalField;
        
        /// <remarks/>
        public MessageDestination messagedestination {
            get {
                return this.messagedestinationField;
            }
            set {
                this.messagedestinationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime startpublish {
            get {
                return this.startpublishField;
            }
            set {
                this.startpublishField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime stoppublish {
            get {
                return this.stoppublishField;
            }
            set {
                this.stoppublishField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int interval {
            get {
                return this.intervalField;
            }
            set {
                this.intervalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:nJupiter:Messaging:MessageDestination")]
    public partial class MessageDestination {
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:njupiter:messaging:webservice")]
    public partial class MessageConsumer {
        
        private MessageDestination messagedestinationField;
        
        private long idField;
        
        private System.DateTime createdField;
        
        private string notificationurlField;
        
        /// <remarks/>
        public MessageDestination messagedestination {
            get {
                return this.messagedestinationField;
            }
            set {
                this.messagedestinationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string notificationurl {
            get {
                return this.notificationurlField;
            }
            set {
                this.notificationurlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void PublishCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void AddMessageConsumerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void NotifyCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591