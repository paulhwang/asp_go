﻿/*
  Copyrights reserved
  Written by Paul Hwang
*/
function PreludeRootObject() {
    "use strict";
    this.init__ = function() {
        this.thePhwangObject = new PhwangClass(this);
        this.thePreludeRenderObject = new PreludeRenderObject(this);
        this.phwangObject().initObject();
        this.theAjaxResponseObject = new PreludeAjaxResponseClass(this);
        this.preludeRenderObject().renderPreludePage();
    };
    this.objectName = function(){return "PreludeRootObject";};
    this.phwangObject = function () { return this.thePhwangObject; };
    this.preludeRenderObject = function () { return this.thePreludeRenderObject;};
    this.phwangAjaxObject = function(){return this.phwangObject().phwangAjaxObject();};
    this.phwangLinkObject = function(){return this.phwangObject().phwangLinkObject();};
    this.htmlObject = function(){return this.theHtmlObject;};
    this.ajaxResponseObject = function(){return this.theAjaxResponseObject;};
    this.debug = function(debug_val, str1_val, str2_val){if (debug_val){ this.logit(str1_val, str2_val);}};
    this.logit = function(str1_val, str2_val){return this.logit_(this.objectName() + "." + str1_val, str2_val);};
    this.abend = function(str1_val, str2_val){return this.abend_(this.objectName() + "." + str1_val, str2_val);};
    this.logit_ = function(str1_val, str2_val){this.phwangObject().LOG_IT(str1_val, str2_val);};
    this.abend_ = function(str1_val, str2_val){this.phwangObject().ABEND(str1_val, str2_val);};

    ////////////////////////////////////////////////////////////////////////////move to go area
    this.goBaseObject=function(){return this.theGoBaseObject;};
    this.configStorageObject = function(){return this.goBaseObject().configStorageObject();};
    this.configObject = function(){return this.goBaseObject().configObject();};
    this.startNewGoGame = function () {
        this.theGoBaseObject = new GoBaseObject(this);
    };
    ////////////////////////////////////////////////////////////////////////////////////////////////
    this.init__();
}
function PreludeAjaxResponseClass(root_object_val) {
    "use strict";
    this.init__ = function(root_object_val){ this.theRootObject = root_object_val;};
    this.receiveSetupLinkResponse = function (result_val) { this.preludeRenderObject().renderThemePage();};
    this.receiveGetNameListResponse = function(result_val){};
    this.receiveSetupSessionResponse = function(result_val){};
    this.receiveSetupSession2Response = function(result_val){};
    this.receiveSetupSession3Response = function(result_val){};
    this.receivePutSessionDataResponse = function(result_val){this.abend("receivePutSessionDataResponse", "");};
    this.receiveGetSessionDataResponse = function(result_val, data_val){ this.abend("receiveGetSessionDataResponse", "");};
    this.objectName = function(){return "PreludeAjaxClass";};
    this.rootObject = function(){return this.theRootObject;};
    this.phwangObject = function(){return this.rootObject().phwangObject();};
    this.preludeRenderObject = function () { return this.rootObject().preludeRenderObject(); };
    this.htmlObject = function(){return this.rootObject().htmlObject();};
    this.debug = function(debug_val, str1_val, str2_val){ if (debug_val){ this.logit(str1_val, str2_val);}};
    this.logit = function(str1_val, str2_val){return this.rootObject().logit_(this.objectName() + "." + str1_val, str2_val);};
    this.abend = function(str1_val, str2_val){return this.rootObject().abend_(this.objectName() + "." + str1_val, str2_val);};
    this.init__(root_object_val);
}
var login_main = function() {"use strict"; new PreludeRootObject();};
//$(document).ready(login_main);
window.onload = login_main;
