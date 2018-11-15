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
        themeComponent(props)
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
    if (props.prelude_on) {
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

function themeComponent(props) {
    if (props.prelude_on) {
        return React.createElement("section", { "className": "theme_section" },
            React.createElement("h1", null, "Select the Theme"),
            React.createElement("button", { "className": "go_button" }, "Play Go"),
        );
    }
    else {
        return null;
    }
}
