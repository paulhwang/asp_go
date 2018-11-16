/*
  Copyrights reserved
  Written by Paul Hwang
*/

function PhwangClass(root_val) {
    "use strict";
    this.init__ = function(root_val) {this.theRootObject = root_val;};
    this.initObject = function() {
        this.thePhwangAjaxObject = new PhwangAjaxClass(this);
        this.theLinkObject = new LinkClass(this);
        this.thePhwangPortObject = new PhwangPortClass(this);
        this.debug(true, "initObject", "");
    };
    this.decodeNumber = function(input_val, size_val) {
        var output = 0;
        for (var index = 0; index < size_val; index++) {
            output *= 10;
            output += input_val.charAt(index) - '0';
        }
        return output;
    };
    this.serverHttpHeader = function() {return "http://" + window.location.hostname + ":" + window.location.port + "/";};
    this.serverHttpsHeader = function() {return "https://" + window.location.hostname + ":" + window.location.port + "/";};
    this.objectName = function() {return "PhwangClass";};
    this.rootObject = function() {return this.theRootObject;};
    this.phwangAjaxObject = function() {return this.thePhwangAjaxObject;};
    this.linkObject = function() {return this.theLinkObject;};
    this.phwangPortObject = function() {return this.thePhwangPortObject;};
    this.debug = function(debug_val, str1_val, str2_val) {if (debug_val) {this.logit(str1_val, str2_val);}};
    this.logit = function(str1_val, str2_val) {return this.LOG_IT(this.objectName() + "." + str1_val, str2_val);};
    this.abend = function(str1_val, str2_val) {return this.ABEND(this.objectName() + "." + str1_val, str2_val);};
    this.LOG_IT = function(str1_val, str2_val) {window.console.log(str1_val + "() " + str2_val);};
    this.ABEND = function(str1_val, str2_val) {window.console.log("***ABEND*** " + str1_val + "() " + str2_val); window.alert("***ABEND*** " + str1_val + "() " + str2_val); var x = junk;};
    this.init__(root_val);
}
function PhwangPortClass(phwang_object_val) {
    "use strict";
    this.init__ = function (phwang_object_val) {this.thePhwangObject = phwang_object_val;};
    this.receiveSetupLinkResponse = function(result_val) {this.rootObject().ajaxResponseObject().receiveSetupLinkResponse(result_val);};
    this.receiveGetNameListResponse = function (result_val) { this.rootObject().ajaxResponseObject().receiveGetNameListResponse(result_val);};
    this.receiveSetupSessionResponse = function (result_val) { this.rootObject().ajaxResponseObject().receiveSetupSessionResponse(result_val);};
    this.receiveSetupSession2Response = function (result_val) { this.rootObject().ajaxResponseObject().receiveSetupSession2Response(result_val);};
    this.receiveSetupSession3Response = function (result_val) { this.rootObject().ajaxResponseObject().receiveSetupSession3Response(result_val);};
    this.receivePutSessionDataResponse = function (result_val) { this.rootObject().ajaxResponseObject().receivePutSessionDataResponse(result_val, data_val);};
    this.receiveGetSessionDataResponse = function (result_val, data_val) { this.rootObject().ajaxResponseObject().receiveSetupSessionResponse(result_val, data_val);};
    this.objectName = function() {return "PhwangPortClass";};
    this.phwangObject = function() {return this.thePhwangObject;};
    this.rootObject = function() {return this.phwangObject().rootObject();};
    this.phwangAjaxObject = function() {return this.phwangObject().phwangAjaxObject();};
    this.phwangSessionObject = function() {return this.phwangObject().phwangSessionObject();};
    this.debug = function(debug_val, str1_val, str2_val) {if (debug_val) {this.logit(str1_val, str2_val);}};
    this.logit = function(str1_val, str2_val) {return this.phwangObject().LOG_IT(this.objectName() + "." + str1_val, str2_val);};
    this.abend = function(str1_val, str2_val) {return this.phwangObject().ABEND(this.objectName() + "." + str1_val, str2_val);};
    this.init__(phwang_object_val);
}
function PhwangQueueClass(phwang_object_val) {
    "use strict";
    this.init__ = function(phwang_object_val) {
        this.thePhwangObject = phwang_object_val;
        this.theMaxQueueLength = 1;
        this.theQueueLength = 0;
        this.theQueueArray = [this.maxQueueLength()];
    };
    this.enqueueData = function(data_val) {
        if (this.queueLength() >= this.maxQueueLength()) {this.abend("enqueueData", "queue full"); return;}
        this.queueArray()[this.queueLength()] = data_val;
        this.incrementQueueLength();
    };
    this.dequeueData = function() {
        if (this.queueLength() === 0) {return 0;}
        var data = this.queueArray()[0];
        this.decrementQueueLength();
        for (var i = 0; i < this.queueLength(); i++) {this.queueArray()[i] = this.queueArray()[i + 1];}
        return data;
    };
    this.maxQueueLength = function() {return this.theMaxQueueLength};
    this.queueLength = function() {return this.theQueueLength};
    this.incrementQueueLength = function() {this.theQueueLength += 1};
    this.decrementQueueLength = function() {this.theQueueLength -= 1};
    this.queueArray = function() {return this.theQueueArray;}
    this.objectName = function() {return "PhwangQueueClass";};
    this.phwangObject = function() {return this.thePhwangObject;};
    this.debug = function(debug_val, str1_val, str2_val) {if (debug_val) {this.logit(str1_val, str2_val);}};
    this.logit = function(str1_val, str2_val) {return this.phwangObject().LOG_IT(this.objectName() + "." + str1_val, str2_val);};
    this.abend = function(str1_val, str2_val) {return this.phwangObject().ABEND(this.objectName() + "." + str1_val, str2_val);};
    this.init__(phwang_object_val);
}
