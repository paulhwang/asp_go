/*
  Copyrights reserved
  Written by Paul Hwang
*/
function PreludeRootObject() {
    "use strict";
    this.init__ = function () {
        this.thePhwangObject = new PhwangClass(this);
        this.phwangObject().initObject();
        this.theAjaxObject = new LoginAjaxClass(this);
        this.renderPreludePage();
        this.debug(true, "init__", "myName=" + this.phwangLinkObject().myName() + " linkId=" + this.phwangLinkObject().linkId());
    };
    this.theDispalySwitch = {
        prelude_on: false,
        sign_up_on: false,
        sign_in_on: false,
        theme_on: false,
        go_config_on: false,
        go_game_on: false
    }
    this.dispalySwitch = function () { return this.theDispalySwitch;}
    this.setupPreludeSwitch = function () {
        this.theDispalySwitch.prelude_on = true;
        this.theDispalySwitch.sign_up_on = false;
        this.theDispalySwitch.sign_in_on = false;
        this.theDispalySwitch.theme_on = false;
        this.theDispalySwitch.go_config_on = false;
        this.theDispalySwitch.go_game_on = false;
    }
    this.renderPreludePage = function() {
        this.setupPreludeSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        var this0 = this;
        $(".prelude_section .sign_up_button").on("click", function () {
            this0.debug(true, "renderPreludePage click function", ".prelude_section .sign_up_button");
            this0.renderSignUpPage();
        });
        $(".prelude_section .sign_in_button").on("click", function () {
            this0.debug(true, "renderPreludePage click function", ".prelude_section .sign_in_button");
            this0.renderSignInPage();
        });
        $(".prelude_section .theme_button").on("click", function () {
            this0.debug(true, "renderPreludePage click function", ".prelude_section .theme_button");
            this0.renderThemePage();
        });
    };
    this.setupSignUpSwitch = function () {
        this.theDispalySwitch.prelude_on = false;
        this.theDispalySwitch.sign_up_on = true;
        this.theDispalySwitch.sign_in_on = false;
        this.theDispalySwitch.theme_on = false;
        this.theDispalySwitch.go_config_on = false;
        this.theDispalySwitch.go_game_on = false;
     }
    this.renderSignUpPage = function() {
        //ReactDOM.render(React.createElement(SignUpComponentClass, null, null), document.getElementById("phwang_prelude"));
        this.setupSignUpSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        var this0 = this;
        $(".sign_up_section .sign_up_button").on("click", function () {
            this0.debug(true, "renderSignUpPage click function", ".sign_up_section .sign_up_button");
            this0.renderPreludePage();
        });
    };
    this.setupSignInSwitch = function () {
        this.theDispalySwitch.prelude_on = false;
        this.theDispalySwitch.sign_up_on = false;
        this.theDispalySwitch.sign_in_on = true;
        this.theDispalySwitch.theme_on = false;
        this.theDispalySwitch.go_config_on = false;
        this.theDispalySwitch.go_game_on = false;
    }
    this.renderSignInPage = function () {
        //ReactDOM.render(React.createElement(SignInComponentClass, null, null), document.getElementById("phwang_prelude"));
        this.setupSignInSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        var this0 = this;
        $(".sign_in_section .sign_in_button").on("click", function () {
            this0.debug(true, "renderSignUpPage click function", ".sign_in_section .sign_in_button");
            this0.phwangLinkObject().setMyName($(".sign_in_section .sign_in_name").val());
            var password = $(".sign_in_section .sign_in_password").val();
            this0.debug(true, "renderSignInPage", "myName=" + this0.phwangLinkObject().myName() + " password=" + password);
            if (this0.phwangLinkObject().myName()) {
                this0.phwangAjaxObject().setupLink(this0.phwangLinkObject(), password);
            }
            //this0.renderThemePage();
        });
    };
    this.setupThemeSwitch = function () {
        this.theDispalySwitch.prelude_on = false;
        this.theDispalySwitch.sign_up_on = false;
        this.theDispalySwitch.sign_in_on = false;
        this.theDispalySwitch.theme_on = true;
        this.theDispalySwitch.go_config_on = false;
        this.theDispalySwitch.go_game_on = false;
    }
    this.renderThemePage = function () {
        this.phwangAjaxObject().startWatchDog(this.phwangLinkObject());
        //ReactDOM.render(React.createElement(ThemeComponentClass, null, null), document.getElementById("phwang_prelude"));
        this.setupThemeSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        var this0 = this;
        $(".theme_section .go_button").on("click", function () {
            this0.debug(true, "renderThemePage click function", ".theme_section .go_button");
            this0.renderGoConfigPage();
        });
    };
    this.setupGoConfigSwitch = function () {
        this.theDispalySwitch.prelude_on = false;
        this.theDispalySwitch.sign_up_on = false;
        this.theDispalySwitch.sign_in_on = false;
        this.theDispalySwitch.theme_on = false;
        this.theDispalySwitch.go_config_on = true;
        this.theDispalySwitch.go_game_on = false;
    }
    this.renderGoConfigPage = function () {
        this.startNewGoGame();
        this.setupGoConfigSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        this.renderNameList();
        var this0 = this;
        $(".config_section .config_button").on("click", function () {
            this0.configStorageObject().setHisName($(".peer_name_paragraph select").val());
            this0.configStorageObject().setMyColor($(".config_section .go_config_section .stone_color").val());
            this0.configStorageObject().setBoardSize($(".config_section .go_config_section .board_size").val());
            this0.configStorageObject().setKomiPoint($(".config_section .go_config_section .komi").val());
            this0.configStorageObject().setHandicapPoint($(".config_section .go_config_section .handicap").val());
            var encoded_config = this0.configStorageObject().encodeConfig(this0.phwangLinkObject().myName());
            this0.debug(true, "setupHtmlInput", "boardSize=" + this0.configStorageObject().boardSize() + " myColor=" + this0.configStorageObject().myColor() + " komi=" + this0.configStorageObject().komiPoint() + " handicap=" + this0.configStorageObject().handicapPoint());
            this0.phwangAjaxObject().setupSession(this0.phwangLinkObject(), this0.configStorageObject().hisName(), encoded_config);
            this0.renderGoGamePage();
        });
        //window.open(this.phwangObject().serverHttpHeader() + "Go/GoSetup", "_self");
    };
    this.renderNameList = function () {
        for (var i = 0; i < this.phwangLinkObject().nameListLength(); i++) {
            $('.peer_name_paragraph select').append($('<option>', { value: this.phwangLinkObject().nameListElement(i), text: this.phwangLinkObject().nameListElement(i) }));
        }
    };
    this.setupGoGameSwitch = function () {
        this.theDispalySwitch.prelude_on = false;
        this.theDispalySwitch.sign_up_on = false;
        this.theDispalySwitch.sign_in_on = false;
        this.theDispalySwitch.theme_on = false;
        this.theDispalySwitch.go_config_on = false;
        this.theDispalySwitch.go_game_on = true;
    }
    this.renderGoGamePage = function () {
        this.setupGoGameSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        this.goBaseObject().init_game();

    };
    this.objectName = function () { return "PreludeRootObject"; };
    this.phwangObject = function () { return this.thePhwangObject; };
    this.phwangAjaxObject = function () { return this.phwangObject().phwangAjaxObject(); };
    this.phwangLinkObject = function () { return this.phwangObject().phwangLinkObject(); };
    this.phwangSessionObject = function () { return this.phwangObject().phwangSessionObject(); };
    this.htmlObject = function () { return this.theHtmlObject; };
    this.ajaxObject = function () { return this.theAjaxObject; };
    this.debug = function (debug_val, str1_val, str2_val) { if (debug_val) { this.logit(str1_val, str2_val); } };
    this.logit = function (str1_val, str2_val) { return this.logit_(this.objectName() + "." + str1_val, str2_val); };
    this.abend = function (str1_val, str2_val) { return this.abend_(this.objectName() + "." + str1_val, str2_val); };
    this.logit_ = function (str1_val, str2_val) { this.phwangObject().LOG_IT(str1_val, str2_val); };
    this.abend_ = function (str1_val, str2_val) { this.phwangObject().ABEND(str1_val, str2_val); };

    ////////////////////////////////////////////////////////////////////////////move to go area
    this.goBaseObject=function(){return this.theGoBaseObject;};
    this.configStorageObject = function () { return this.goBaseObject().configStorageObject(); };
    this.configObject = function () { return this.goBaseObject().configObject(); };
    this.startNewGoGame = function() {
        this.theGoBaseObject = new GoBaseObject(this);
        //this.theConfigStorageObject = new GoConfigStorageObject(this);
        //this.theConfigObject = new GoConfigObject(this);
    };
    ////////////////////////////////////////////////////////////////////////////////////////////////
    this.init__();
}
function LoginHtmlObject(root_object_val) {
    "use strict";
    this.componentName = function () { return "account_sign_in_html"; };
    this.gotoNextPage = function () { window.open(this.phwangObject().serverHttpHeader() + "Go/GoSetup", "_self") };
    this.init__ = function (root_object_val) { this.theRootObject = root_object_val; this.setupHtmlInput(); };
    this.setupHtmlInput = function () {
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, null, null), document.getElementById("phwang_prelude"));
        var this0 = this;
        $(".prelude_section .sign_up_button").on("click", function () {
            this0.debug(true, "click function", ".prelude_section .sign_up_button");
            ReactDOM.render(React.createElement(SignUpComponentClass, null, null), document.getElementById("phwang_prelude"));
            $(".sign_up_section .sign_up_button").on("click", function () {
                this0.debug(true, "click function", ".sign_up_section .sign_up_button");
                ReactDOM.render(React.createElement(PhwangPreludeComponentClass, null, null), document.getElementById("phwang_prelude"));

            });

        });
        $(".sign_up_section .sign_up_button").on("click", function () {
            this0.debug(true, "click function", ".sign_up_section .sign_up_button");
            ReactDOM.render(React.createElement(PhwangPreludeComponentClass, null, null), document.getElementById("phwang_prelude"));

        });
    };
    this.objectName = function () { return "LoginHtmlObject"; };
    this.rootObject = function () { return this.theRootObject; };
    this.phwangObject = function () { return this.rootObject().phwangObject(); };
    this.phwangAjaxObject = function () { return this.phwangObject().phwangAjaxObject(); };
    this.phwangLinkObject = function () { return this.phwangObject().phwangLinkObject(); };
    this.ajaxObject = function () { return this.rootObject().ajaxObject(); };
    this.debug = function (debug_val, str1_val, str2_val) { if (debug_val) { this.logit(str1_val, str2_val); } };
    this.logit = function (str1_val, str2_val) { return this.rootObject().logit_(this.objectName() + "." + str1_val, str2_val); };
    this.abend = function (str1_val, str2_val) { return this.rootObject().abend_(this.objectName() + "." + str1_val, str2_val); };
    this.init__(root_object_val);
}
function LoginAjaxClass(root_object_val) {
    "use strict";
    this.init__ = function (root_object_val) { this.theRootObject = root_object_val; };
    this.receiveSetupLinkResponse = function (result_val) {
        //this.htmlObject().gotoNextPage();
        //window.open(this.phwangObject().serverHttpHeader() + "Go/GoSetup", "_self");
        this.rootObject().renderThemePage();
    };
    this.receiveGetNameListResponse = function (result_val) { };
    this.receiveSetupSessionResponse = function (result_val) { };
    this.receiveSetupSession2Response = function (result_val) { };
    this.receiveSetupSession3Response = function (result_val) { };
    this.receivePutSessionDataResponse = function (result_val) { };
    this.receiveGetSessionDataResponse = function (result_val, data_val) { };
    this.objectName = function () { return "LoginAjaxClass"; };
    this.rootObject = function () { return this.theRootObject; };
    this.phwangObject = function () { return this.rootObject().phwangObject(); };
    this.htmlObject = function () { return this.rootObject().htmlObject(); };
    this.debug = function (debug_val, str1_val, str2_val) { if (debug_val) { this.logit(str1_val, str2_val); } };
    this.logit = function (str1_val, str2_val) { return this.rootObject().logit_(this.objectName() + "." + str1_val, str2_val); };
    this.abend = function (str1_val, str2_val) { return this.rootObject().abend_(this.objectName() + "." + str1_val, str2_val); };
    this.init__(root_object_val);
}
var login_main = function () { "use strict"; new PreludeRootObject(); };
//$(document).ready(login_main);
window.onload = login_main;
