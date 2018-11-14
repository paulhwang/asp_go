/*
  Copyrights reserved
  Written by Paul Hwang
*/

function PhwangPreludeComponentClass (props) {
    //render() {
    const aaa = props.switch_on;
    console.log("bbb=" + aaa);
    if (aaa)
        return preludeComponent();
        /*
        return React.createElement("section", { className: "prelude_section" },
            React.createElement("h1", null, "Let's Play Go!"),
            React.createElement("p", { className: "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
            React.createElement("button", { className: "sign_up_button" }, "Sign up"),
            React.createElement("button", { className: "sign_in_button" }, "Sign in"),
            React.createElement("button", { className: "theme_button" }, "Theme"),
            React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Sign in")),
            //<p><a href="http://localhost:8168/Account/AccountSignUp" class="btn btn-primary btn-lg">Sign up &raquo;</a></p>
        );
        */
    else
        return React.createElement("section", { className: "prelude_section" },
        React.createElement("h1", null, "Let's Play Go!bbbbbbbbbbbbbbf"),
        React.createElement("p", { className: "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
        React.createElement("button", { className: "sign_up_button" }, "Sign up"),
        React.createElement("button", { className: "sign_in_button" }, "Sign in"),
        React.createElement("button", { className: "theme_button" }, "Theme"),
        React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Sign in")),
        //<p><a href="http://localhost:8168/Account/AccountSignUp" class="btn btn-primary btn-lg">Sign up &raquo;</a></p>
    );
    //}
}

function preludeComponent() {
        return React.createElement("section", { className: "prelude_section" },
            React.createElement("h1", null, "Let's Play Go! aaaaaaaaaaaaaaaaaaaaaaaaa"),
            React.createElement("p", { className: "lead" }, "Let's Play Go is a free web platform to play Go Game with people in the world."),
            React.createElement("button", { className: "sign_up_button" }, "Sign up"),
            React.createElement("button", { className: "sign_in_button" }, "Sign in"),
            React.createElement("button", { className: "theme_button" }, "Theme"),
            React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Sign in")),
            //<p><a href="http://localhost:8168/Account/AccountSignUp" class="btn btn-primary btn-lg">Sign up &raquo;</a></p>
    );

}