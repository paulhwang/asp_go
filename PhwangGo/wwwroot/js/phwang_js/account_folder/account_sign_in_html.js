
class Hello extends React.Component {
    render() {
        return React.createElement(
            "body",
            null,
            React.createElement(
                "h2",
                null,
                "Account Sign In"
            ),
            React.createElement(
                "section",
                { "class": "login_section" },
                React.createElement(
                    "p",
                    null,
                    "Name:",
                    React.createElement("input", {
                        type: "text",
                        "class": "login_name",
                        placeholder: "Enter your name"
                    })
                ),
                React.createElement(
                    "p",
                    null,
                    "Password:",
                    React.createElement("input", {
                        type: "text",
                        "class": "login_password",
                        placeholder: "Enter your password"
                    })
                ),
                React.createElement(
                    "button",
                    { "class": "login_button" },
                    "Login"
                )
            )
        );
    }
}

ReactDOM.render(
    React.createElement(Hello, null, null),
    document.getElementById('account_sign_in_html')
);

