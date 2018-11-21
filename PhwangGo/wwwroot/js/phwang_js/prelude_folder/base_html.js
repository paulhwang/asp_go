/*
  Copyrights reserved
  Written by Paul Hwang
*/
var TheBaseHtmlObject;
function BaseHtmlObject(root_object_val) {
    "use strict";
    this.init__ = root_object_val => {
        this.theRootObject = root_object_val;
        TheBaseHtmlObject = this;
        this.debug(true, "init__", "");
    };
    this.TestAreaComponent0 = React.createClass({
        _onClick: function () {
            var this0 = TheBaseHtmlObject;
            this0.debug(true, "preludeComponent", "_onClick");
        },
        render: function () {
            var this0 = ThePreludeHtmlObject;
            this0.debug(true, "preludeComponent", "start");
            return React.DOM.section({ className: "prelude_section" },
                React.DOM.h1(null, "Let's Play Go!"),
                React.DOM.p({ className: "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
                React.DOM.button({ className: "sign_up_button" }, "Sign iup"),
                React.DOM.button({ className: "sign_in_button", onClick: this._onClick }, "Sign in"),
                React.DOM.button({ className: "theme_button" }, "Theme"),
            );
        }
    });
    this.randerBaseComponent = () => {
        ReactDOM.render(React.createElement(this.TestAreaComponent0, { text: "Jose" }), document.getElementById("phwang_prelude"));
    };
    this.objectName = () => "BaseHtmlObject";
    this.rootObject = () => this.theRootObject;
    this.phwangObject = () => this.rootObject().phwangObject();
    this.debug = (debug_val, str1_val, str2_val) => { if (debug_val) { this.logit(str1_val, str2_val); } };
    this.logit = (str1_val, str2_val) => { this.logit_(this.objectName() + "." + str1_val, str2_val); };
    this.abend = (str1_val, str2_val) => { this.abend_(this.objectName() + "." + str1_val, str2_val); };
    this.logit_ = (str1_val, str2_val) => { this.phwangObject().LOG_IT(str1_val, str2_val); };
    this.abend_ = (str1_val, str2_val) => { this.phwangObject().ABEND(str1_val, str2_val); };
    this.init__(root_object_val);
}