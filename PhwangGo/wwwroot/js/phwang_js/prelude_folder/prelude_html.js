/*
  Copyrights reserved
  Written by Paul Hwang
*/

function PhwangPreludeComponentClass (props) {
    //render() {
    console.log("prelude_on=" + props.prelude_on);
    return React.createElement("body", null,
        preludeComponent(props),
        signUpComponent(props),
        signInComponent(props),
        themeComponent(props),
        goConfigComponent(props),
        goGameComponent(props)
        );
}

function preludeComponent(props) {
    if (props.prelude_on) {
        return React.createElement("section", { className: "prelude_section" },
            React.createElement("h1", null, "Let's Play Go!"),
            React.createElement("p", { className: "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
            React.createElement("button", { className: "sign_up_button" }, "Sign up"),
            React.createElement("button", { className: "sign_in_button" }, "Sign in"),
            React.createElement("button", { className: "theme_button" }, "Theme"),
            React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Sign in")),
            //<p><a href="http://localhost:8168/Account/AccountSignUp" class="btn btn-primary btn-lg">Sign up &raquo;</a></p>
        );
    }
    else {
        return null;
    }
}

function signUpComponent(props) {
    if (props.sign_up_on) {
        return React.createElement(
            "section",
            { "className": "sign_up_section" },
            React.createElement(
                "h2",
                null,
                "Account Sign Up"
            ),

            React.createElement(
                "p",
                null,
                "Name:",
                React.createElement("input", {
                    type: "text",
                    "className": "sign_up_name",
                    placeholder: "Enter your account name"
                })
            ),

            React.createElement(
                "p",
                null,
                "Password:",
                React.createElement("input", {
                    type: "text",
                    "className": "sign_up_password",
                    placeholder: "Enter your password"
                })
            ),

            React.createElement(
                "p",
                null,
                "email:",
                React.createElement("input", {
                    type: "text",
                    "className": "sign_up_email",
                    placeholder: "Enter your email"
                })
            ),

            React.createElement(
                "button",
                { "className": "sign_up_button" },
                "Sign up"
            )
        );
    }
    else {
        return null;
    }
}

function signInComponent(props) {
    if (props.sign_in_on) {
        return React.createElement(
            "section",
            { "className": "sign_in_section" },
            React.createElement(
                "h2",
                null,
                "Account Sign In"
            ),

            React.createElement(
                "p",
                null,
                "Name:",
                React.createElement("input", {
                    type: "text",
                    "className": "sign_in_name",
                    placeholder: "Enter your account name"
                })
            ),

            React.createElement(
                "p",
                null,
                "Password:",
                React.createElement("input", {
                    type: "text",
                    "className": "sign_in_password",
                    placeholder: "Enter your password"
                })
            ),

            React.createElement(
                "button",
                { "className": "sign_in_button" },
                "Sign in"
            )
        );
    }
    else {
        return null;
    }
}

function themeComponent(props) {
    if (props.theme_on) {
        return React.createElement("section", { "className": "theme_section" },
            React.createElement("h1", null, "Select the Theme"),
            React.createElement("button", { "className": "go_button" }, "Play Go"),
        );
    }
    else {
        return null;
    }
}

function goConfigComponent(props) {
    if (props.go_config_on) {
        return React.createElement(
            "body",
            null,
            React.createElement(
                "h2",
                null,
                "GoSetup"
            ),

            React.createElement(
                "section",
                { "className": "config_section" },
                React.createElement(
                    "p",
                    { "className": "peer_name_paragraph" },
                    "Peer Name:",
                    React.createElement(
                        "select",
                        { "name": "opponent" },
                        null
                    )
                ),

                React.createElement(
                    "p",
                    { "className": "peer_game_paragraph" },
                    "Game",
                    React.createElement(
                        "select",
                        null,
                        React.createElement("option", { "value": "Go" }, "Go"),
                        React.createElement("option", { "value": "game1" }, "game1"),
                        React.createElement("option", { "value": "game2" }, "game2")
                    ),
                    React.createElement(
                        "button",
                        null,
                        "Select"
                    )
                ),

                React.createElement(
                    "section",
                    { "className": "go_config_section" },
                    React.createElement(
                        "p",
                        null,
                        "Board Size:",
                        React.createElement(
                            "select",
                            { "className": "board_size" },
                            React.createElement("option", { "value": "19" }, "19x19"),
                            React.createElement("option", { "value": "13" }, "13x13"),
                            React.createElement("option", { "value": "9" }, "9x9")
                        )
                    ),

                    React.createElement(
                        "p",
                        null,
                        "Stone Color:",
                        React.createElement(
                            "select",
                            { "className": "stone_color" },
                            React.createElement("option", { "value": "black" }, "Black"),
                            React.createElement("option", { "value": "white" }, "White"),
                        )
                    ),

                    React.createElement(
                        "p",
                        null,
                        "Komi:",
                        React.createElement(
                            "select",
                            { "className": "komi" },
                            React.createElement("option", { "value": "0" }, 0.5),
                            React.createElement("option", { "value": "4" }, 4.5),
                            React.createElement("option", { "value": "5" }, 5.5),
                            React.createElement("option", { "value": "6" }, 6.5),
                            React.createElement("option", { "value": "7" }, 7.5),
                            React.createElement("option", { "value": "8" }, 8.5)
                        )
                    ),

                    React.createElement(
                        "p",
                        null,
                        "Handicap:",
                        React.createElement(
                            "select",
                            { "className": "handicap" },
                            React.createElement("option", { "value": "0" }, 0),
                            React.createElement("option", { "value": "2" }, 2),
                            React.createElement("option", { "value": "3" }, 3),
                            React.createElement("option", { "value": "4" }, 4),
                            React.createElement("option", { "value": "5" }, 5),
                            React.createElement("option", { "value": "6" }, 6),
                            React.createElement("option", { "value": "7" }, 7),
                            React.createElement("option", { "value": "8" }, 8),
                            React.createElement("option", { "value": "9" }, 9),
                            React.createElement("option", { "value": "10" }, 10),
                            React.createElement("option", { "value": "11" }, 11),
                            React.createElement("option", { "value": "12" }, 12),
                            React.createElement("option", { "value": "13" }, 13),
                        )
                    )
                ),

                React.createElement(
                    "button",
                    { "className": "config_button" },
                    "Connect"
                )
            )
        );
    }
    else {
        return null;
    }
}

function goGameComponent(props) {
    if (props.go_game_on) {
        return React.createElement(
            "body",
            null,
            React.createElement(
                "section",
                null,
                React.createElement(
                    "canvas",
                    { "id": "go_canvas" },
                    null
                )
            ),

            React.createElement(
                "section",
                null,
                React.createElement(
                    "p",
                    { "id": "black_score" },
                    "Black 0"
                ),
                React.createElement(
                    "p",
                    { "id": "white_score" },
                    "White 0"
                )
            )
        );
    }
    else {
        return null;
    }
}

