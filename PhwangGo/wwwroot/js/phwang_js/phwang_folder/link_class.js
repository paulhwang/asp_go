/*
 * Copyrights phwang
 * Written by Paul Hwang
 */
function LinkClass(phwang_object_val) {
    "use strict";
    this.init__ = phwang_object_val => {
        this.thePhwangObject = phwang_object_val;
        this.thePhwangLinkStorageObject = new PhwangLinkStorageObject(this);
        this.theNameList = [];
        this.theNameListTag = 0;
        this.theServerNameListTag = 0;
        this.theSessionIndexArray = [0];
        this.theSessionTableArray = [null];
        this.debug(true, "init__", "linkId=" + this.linkId() + " myName=" + this.myName());
    };
    this.myName = () => this.phwangLinkStorageObject().myName();
    this.setMyName = val => {this.phwangLinkStorageObject().setMyName(val);};
    this.linkId = () => this.phwangLinkStorageObject().linkId();
    this.setLinkId = val => {
        if (this.linkId()) {
            //this.abend("setLinkIdIndex", "already exist");
        }
        this.phwangLinkStorageObject().setLinkId(val);
    };
    this.sessionIndexArray = () => this.theSessionIndexArray;
    this.sessionTableArray = () => this.theSessionTableArray;
    this.sessionTableArrayLength = () => this.sessionTableArray().length;
    this.sessionTableArrayElement = val => this.sessionTableArray()[val];
    this.verifyLinkIdIndex = function(id_val) {
        if (this.linkId() === id_val) {
            return true;
        } else {
            return false;
        }
    };
    this.resetLinkStorage = function() {
        this.phwangLinkStorageObject().resetLinkStorage();
    };
    this.mallocSessionAndInsert = session_id_val => {
        if (this.getSession(session_id_val)) {
            this.abend("mallocSessionAndInsert", "session exists: " + session_id_val);
        }
        var session = new PhwangSessionClass(this);
        session.setSessionId(session_id_val);
        this.insertSession(session);
        return session;
    };
    this.insertSession = session_val => {
        this.sessionIndexArray().push(session_val.sessionId());
        this.sessionTableArray().push(session_val);
    };
    this.getSession = session_id_val => {
        this.debug(true, "getSession", "session_id=" + session_id_val);
        var index = this.sessionIndexArray().indexOf(session_id_val);
        if (index === -1) {
            return null;
        } else {
            var session =this.sessionTableArray()[index];
            return session;
        }
    };
    this.nameListTag = () => this.theNameListTag;
    this.setNameListTag = val => {this.theNameListTag = val;};
    this.serverNameListTag = () => this.theServerNameListTag;
    this.setServerNameListTag = val => {this.theServerNameListTag = val;};
    this.nameList = () => this.theNameList;
    this.setNameList = data_val => {this.theNameList = data_val.sort()};
    this.nameListLength = () => this.nameList().length;
    this.nameListElement = index_val => this.nameList()[index_val];
    this.setNameListElement = (index_val, data_val) => {this.nameList()[index_val] = data_val;};
    this.objectName = () => "LinkClass";
    this.phwangLinkStorageObject = () => this.thePhwangLinkStorageObject;
    this.phwangObject = () => this.thePhwangObject;
    this.phwangAjaxObject = () => this.phwangObject().phwangAjaxObject();
    this.debug = (debug_val, str1_val, str2_val) => {if (debug_val) {this.logit(str1_val, str2_val);}};
    this.logit = (str1_val, str2_val) => this.phwangObject().LOG_IT(this.objectName() + "." + str1_val, str2_val);
    this.abend = function(str1_val, str2_val) {return this.phwangObject().ABEND(this.objectName() + "." + str1_val, str2_val);};
    this.init__(phwang_object_val);
}
function PhwangLinkStorageObject(phwang_link_object_val) {
    "use strict";
    this.storage = function() {return sessionStorage;};
    this.init__ = function(phwang_link_object_val) {this.thelinkObject = phwang_link_object_val;};
    this.resetLinkStorage = function() {
        this.resetLinkId();
        this.resetMyName();
        this.resetPassWord();
    };
    this.myName = function() {return this.storage().my_name;};
    this.setMyName = function (val) {this.storage().my_name = val;};
    this.resetMyName = function() {this.setMyName("");};
    this.resetPassWord = function() {this.setPassWord("");};
    this.linkId = function() {return this.storage().link_id;};
    this.setLinkId = function(val) {this.storage().link_id = val;};
    this.resetLinkId = function() {this.setLinkId("");};
    this.objectName = function() {return "PhwangLinkStorageObject";};
    this.linkObject = function() {return this.thelinkObject;};
    this.phwangObject = function() {return this.linkObject().phwangObject();};
    this.debug = function(debug_val, str1_val, str2_val) {if (debug_val) {this.logit(str1_val, str2_val);}};
    this.logit = function(str1_val, str2_val) {return this.phwangObject().LOG_IT(this.objectName() + "." + str1_val, str2_val);};
    this.abend = function(str1_val, str2_val) {return this.phwangObject().ABEND(this.objectName() + "." + str1_val, str2_val);};
    this.init__(phwang_link_object_val);
}
