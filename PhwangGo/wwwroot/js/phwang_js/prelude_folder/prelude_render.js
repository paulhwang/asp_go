﻿/*
  Copyrights reserved
  Written by Paul Hwang
*/

function PreludeRenderObject(root_object_val) {
    "use strict";
    this.init__ = function (root_object_val){
        this.theRootObject = root_object_val;
    }
    this.theDispalySwitch = {
        prelude_on: false,
        sign_up_on: false,
        sign_in_on: false,
        theme_on: false,
        go_config_on: false,
        go_game_on: false
    }
    this.dispalySwitch = function () { return this.theDispalySwitch; }
    this.setupPreludeSwitch = function () {
        this.theDispalySwitch.prelude_on = true;
        this.theDispalySwitch.sign_up_on = false;
        this.theDispalySwitch.sign_in_on = false;
        this.theDispalySwitch.theme_on = false;
        this.theDispalySwitch.go_config_on = false;
        this.theDispalySwitch.go_game_on = false;
    }
    this.renderPreludePage = function () {
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
    this.renderSignUpPage = function () {
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
            this0.linkObject().setMyName($(".sign_in_section .sign_in_name").val());
            var password = $(".sign_in_section .sign_in_password").val();
            this0.debug(true, "renderSignInPage", "myName=" + this0.linkObject().myName() + " password=" + password);
            if (this0.linkObject().myName()) {
                this0.phwangAjaxObject().setupLink(this0.linkObject(), password);
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
        this.phwangAjaxObject().startWatchDog(this.linkObject());
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
        this.setupGoConfigSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        this.renderNameList();
        var this0 = this;
        $(".config_section .config_button").on("click", function () {
            var theme = this0.themeMgrObject().mallocThemeAndInsert();
            theme.configStorageObject().setHisName($(".peer_name_paragraph select").val());
            theme.configStorageObject().setMyColor($(".config_section .go_config_section .stone_color").val());
            theme.configStorageObject().setBoardSize($(".config_section .go_config_section .board_size").val());
            theme.configStorageObject().setKomiPoint($(".config_section .go_config_section .komi").val());
            theme.configStorageObject().setHandicapPoint($(".config_section .go_config_section .handicap").val());
            var encoded_config = theme.configStorageObject().encodeConfig(this0.linkObject().myName());
            this0.debug(true, "setupHtmlInput", "boardSize=" + theme.configStorageObject().boardSize() + " myColor=" + theme.configStorageObject().myColor() + " komi=" + theme.configStorageObject().komiPoint() + " handicap=" + theme.configStorageObject().handicapPoint());
            this0.phwangAjaxObject().setupSession(this0.linkObject(), theme.configStorageObject().hisName(), theme.themeIdStr() + encoded_config);
            //this0.renderGoGamePage();
        });
        //window.open(this.phwangObject().serverHttpHeader() + "Go/GoSetup", "_self");
    };
    this.renderNameList = function () {
        $('.peer_name_paragraph select').empty();
        for (var i = 0; i < this.linkObject().nameListLength(); i++) {
            $('.peer_name_paragraph select').append($('<option>', { value: this.linkObject().nameListElement(i), text: this.linkObject().nameListElement(i) }));
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
    this.renderGoGamePage = function (theme_id_str_val) {
        this.setupGoGameSwitch();
        ReactDOM.render(React.createElement(PhwangPreludeComponentClass, this.dispalySwitch()), document.getElementById("phwang_prelude"));
        var theme = this.themeMgrObject().getTheme(theme_id_str_val);
        theme.init_game();
    };
    this.objectName = function () { return "PreludeRenderObject"; };
    this.rootObject = function () { return this.theRootObject; };
    this.phwangObject = function () { return this.rootObject().phwangObject(); };
    this.phwangAjaxObject = function () { return this.phwangObject().phwangAjaxObject(); };
    this.linkObject = function () { return this.phwangObject().linkObject(); };
    this.themeMgrObject = function () { return this.rootObject().themeMgrObject(); };
    this.debug = function (debug_val, str1_val, str2_val) { if (debug_val) { this.logit(str1_val, str2_val); } };
    this.logit = function (str1_val, str2_val) { return this.logit_(this.objectName() + "." + str1_val, str2_val); };
    this.abend = function (str1_val, str2_val) { return this.abend_(this.objectName() + "." + str1_val, str2_val); };
    this.logit_ = function (str1_val, str2_val) { this.phwangObject().LOG_IT(str1_val, str2_val); };
    this.abend_ = function (str1_val, str2_val) { this.phwangObject().ABEND(str1_val, str2_val); };
    this.init__(root_object_val);
}

