/*
  Copyrights reserved
  Written by Paul Hwang
*/

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
                { "className": "login_section" },


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
                            React.createElement("option", { "value":  "9" }, "9x9")
                        )
                    )
                ),

                React.createElement(
                    "p",
                    null,
                    "Name:",
                    React.createElement("input", {
                        type: "text",
                        "className": "login_name",
                        placeholder: "Enter your name"
                    })
                ),
                React.createElement(
                    "button",
                    { "className": "login_button" },
                    "Login"
                )
            )
        );
    }
}

ReactDOM.render(
    React.createElement(Hello, null, null),
    document.getElementById('go_config_html')
);

