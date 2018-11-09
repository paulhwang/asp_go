/*
  Copyrights reserved
  Written by Paul Hwang
*/
/*
<body>
    <section class="go_canvas_section">
        <canvas id="go_canvas">
    </section>
        <section>
            <p id="black_score">Black: 0</p>
        </section>
        <section>
            <p id="white_score">White: 0</p>
        </section>
</body>
*/


class Hello extends React.Component {
    render() {
        return React.createElement(
            "body",
            null,
            /*
            React.createElement(
                "section",
                null,
                React.createElement(
                    "canvas",
                    { "id": "go_canvas" },
                    null
                )
            ),
 */
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
            ),
            React.createElement(
                "section",
                { "className": "login_section" },
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
    document.getElementById('go_html')
);

