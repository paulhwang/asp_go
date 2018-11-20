/*
  Copyrights reserved
  Written by Paul Hwang
*/
var thePreludeSwitch = false;
var theSignUpSwitch = false;
var theSignInSwitch = false;
var theThemeSwitch = false;
var theGoConfigSwitch = false;
var theGoGameSwitch = false;
var theDispalySwitch = {
    prelude_switch: preludeSwitch,
    sign_up_switch: signUpSwitch,
    sign_in_switch: signInSwitch,
    theme_switch: themeSwitch,
    go_config_switch: goConfigSwitch,
    go_game_switch: goGameSwitch,
};
function PhwangPreludeComponentClass (props) {
    //render() {
    console.log("prelude_on=" + props.prelude_on);
    return React.createElement("body", null,
        //React.createElement(preludeComponent1),
        preludeComponent(props),
        signUpComponent(props),
        signInComponent(props),
        themeComponent(props),
        goConfigComponent(props),
        goGameComponent(props)
        );
}
function preludeComponent(props) {
    if (props.prelude_switch()) {
        return React.DOM.section({ className: "prelude_section" },
            React.DOM.h1(null, "Let's Play Go!"),
            React.DOM.p({ className: "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
            React.DOM.button({ className: "sign_up_button" }, "Sign iup"),
            React.DOM.button({ className: "sign_in_button" }, "Sign in"),
            React.DOM.button({ className: "theme_button" }, "Theme"),
            React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Sign in")),
            //<p><a href="http://localhost:8168/Account/AccountSignUp" class="btn btn-primary btn-lg">Sign up &raquo;</a></p>
        );
    }
    else {
        return null;
    }
}
var preludeComponent1 = React.createClass({
    propTypes: {
        prelude_switch: React.PropTypes.func.isRequired,
    },
    render: function () {
        if (this.props.prelude_switch()) {
            return React.DOM.section({ className: "prelude_section" },
                React.DOM.h1(null, "Let's Play Go!"),
                React.DOM.p({ className: "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
                React.DOM.button({ className: "sign_up_button" }, "Sign iup"),
                React.DOM.button({ className: "sign_in_button" }, "Sign in"),
                React.DOM.button({ className: "theme_button" }, "Theme"),
                React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Sign in")),
                //<p><a href="http://localhost:8168/Account/AccountSignUp" class="btn btn-primary btn-lg">Sign up &raquo;</a></p>
            );
        }
        else {
            return null;
        }
    }
});
function signUpComponent(props) {
    if (props.sign_up_switch()) {
        return React.DOM.section({ className: "sign_up_section" },
            React.DOM.h2(null, "Account Sign Up"),
            React.DOM.p(null, "Name:", React.DOM.input({ className: "sign_up_name", placeholder: "Enter your account name" })),
            React.DOM.p(null, "Password:", React.DOM.input({ className: "sign_up_password", placeholder: "Enter your password" })),
            React.DOM.p(null, "email:", React.DOM.input({ className: "sign_up_email", placeholder: "Enter your email" })),
            React.DOM.button({ className: "sign_up_button" }, "Sign up"),
        );
    }
    else {
        return null;
    }
}
function signInComponent(props) {
    if (props.sign_in_switch()) {
        return React.DOM.section({ className: "sign_in_section" },
            React.DOM.h2(null, "Account Sign In"),
            React.DOM.p(null, "Name:", React.DOM.input({ className: "sign_in_name", placeholder: "Enter your account name" })),
            React.DOM.p(null, "Password:", React.DOM.input({ className: "sign_in_password", placeholder: "Enter your password" })),
            React.DOM.button({ className: "sign_in_button" }, "Sign in" ),
        );
    }
    else {
        return null;
    }
}
function themeComponent(props) {
    if (props.theme_switch()) {
       return React.createElement("section", { "className": "theme_section" },
            React.DOM.h1(null, "Select the Theme"),
            React.DOM.button( { "className": "go_button" }, "Play Go"),
        );
    }
    else {
        return null;
    }
}
function goConfigComponent(props) {
    if (props.go_config_switch()) {
        return React.createElement(
            "body",
            null,
            React.DOM.h2(null, "GoSetup"),

            React.DOM.section(
                { "className": "config_section" },
                React.DOM.p(
                    { "className": "peer_name_paragraph" },
                    "Peer Name:",
                    React.DOM.select(
                        { "name": "opponent" },
                        null
                    )
                ),
                React.DOM.p(
                    { "className": "peer_game_paragraph" },
                    "Game",
                    React.DOM.select(
                        null,
                        React.DOM.option( { "value": "Go" }, "Go"),
                        React.DOM.option( { "value": "game1" }, "game1"),
                        React.DOM.option({ "value": "game2" }, "game2")
                    ),
                    React.DOM.button(null, "Select"),
                ),
                React.DOM.section(
                    { "className": "go_config_section" },
                    React.DOM.p(
                        null,
                        "Board Size:",
                        React.DOM.select(
                            { "className": "board_size" },
                            React.DOM.option( { "value": "19" }, "19x19"),
                            React.DOM.option( { "value": "13" }, "13x13"),
                            React.DOM.option( { "value": "9" }, "9x9"),
                        )
                    ),
                    React.DOM.p(
                        null,
                        "Stone Color:",
                        React.DOM.select(
                            { "className": "stone_color" },
                            React.DOM.option( { "value": "black" }, "Black"),
                            React.DOM.option( { "value": "white" }, "White"),
                        )
                    ),
                    React.DOM.p(
                        null,
                        "Komi:",
                        React.DOM.select(
                            { "className": "komi" },
                            React.DOM.option( { "value": "0" }, 0.5),
                            React.DOM.option( { "value": "4" }, 4.5),
                            React.DOM.option( { "value": "5" }, 5.5),
                            React.DOM.option( { "value": "6" }, 6.5),
                            React.DOM.option( { "value": "7" }, 7.5),
                            React.DOM.option( { "value": "8" }, 8.5),
                        )
                    ),
                    React.DOM.p(
                        null,
                        "Handicap:",
                        React.DOM.select(
                            { "className": "handicap" },
                            React.DOM.option( { "value": "0" }, 0),
                            React.DOM.option( { "value": "2" }, 2),
                            React.DOM.option( { "value": "3" }, 3),
                            React.DOM.option( { "value": "4" }, 4),
                            React.DOM.option( { "value": "5" }, 5),
                            React.DOM.option( { "value": "6" }, 6),
                            React.DOM.option( { "value": "7" }, 7),
                            React.DOM.option( { "value": "8" }, 8),
                            React.DOM.option( { "value": "9" }, 9),
                            React.DOM.option( { "value": "10" }, 10),
                            React.DOM.option( { "value": "11" }, 11),
                            React.DOM.option( { "value": "12" }, 12),
                            React.DOM.option( { "value": "13" }, 13),
                        )
                    )
                ),
                React.DOM.button({ "className": "config_button" }, "Connect"),
            )
        );
    }
    else {
        return null;
    }
}
function goGameComponent(props) {
    if (props.go_game_switch()) {
        return React.DOM.body(
            null,
            React.DOM.section(
                null,
                React.DOM.canvas({ id: "go_canvas" })),
            React.DOM.section(
                null,
                React.DOM.p({ "id": "black_score" }, "Black 0"),
                React.DOM.p( { "id": "white_score" }, "White 0")),
        );
    }
    else {
        return null;
    }
}

var dispalySwitch = () => theDispalySwitch;
var preludeSwitch = () => thePreludeSwitch;
var signUpSwitch = () => theSignUpSwitch;
var signInSwitch = () => theSignInSwitch;
var themeSwitch = () => theThemeSwitch;
var goConfigSwitch = () => theGoConfigSwitch;
var goGameSwitch = () => theGoGameSwitch;
var setPreludeSwitch = val => { thePreludeSwitch = val };
var setSignUpSwitch = val => { theSignUpSwitch = val };
var setSignInSwitch = val => { theSignInSwitch = val };
var setThemeSwitch = val => { theThemeSwitch = val };
var setGoConfigSwitch = val => { theGoConfigSwitch = val };
var setGoGameSwitch = val => { theGoGameSwitch = val };
var setupSwitches = (val1, val2, val3, val4, val5, val6) => {
    this.setPreludeSwitch(val1);
    this.setSignUpSwitch(val2);
    this.setSignInSwitch(val3);
    this.setThemeSwitch(val4);
    this.setGoConfigSwitch(val5);
    this.setGoGameSwitch(val6);
};
var setupPreludeSwitch = () => { setupSwitches(true, false, false, false, false, false); };
var setupSignUpSwitch = () => { setupSwitches(false, true, false, false, false, false); };
var setupSignInSwitch = () => { setupSwitches(false, false, true, false, false, false); };
var setupThemeSwitch = () => { setupSwitches(false, false, false, true, false, false); };
var setupGoConfigSwitch = () => { setupSwitches(false, false, false, false, true, false); };
var setupGoGameSwitch = () => { setupSwitches(false, false, false, false, false, true); };


