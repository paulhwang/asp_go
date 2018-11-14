/*
  Copyrights reserved
  Written by Paul Hwang
*/

class PhwangPreludeComponentClass extends React.Component {
    render() {
        return React.createElement("section", { "className": "prelude_section" },
            React.createElement("h1", null, "Let's Play Go!"),
            React.createElement("p", { "className": "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
            React.createElement("button", { "className": "sign_up_button" }, "Sign up"),
            React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Sign in")),
            //<p><a href="http://localhost:8168/Account/AccountSignUp" class="btn btn-primary btn-lg">Sign up &raquo;</a></p>
        );
    }
}

