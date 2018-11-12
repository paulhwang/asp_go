/*
  Copyrights reserved
  Written by Paul Hwang
*/

class PhwangPreludeComponentClass extends React.Component {
    render() {
        return React.createElement("body", null,
            React.createElement("h1", null, "Select the Theme"),
            React.createElement("p", null, React.createElement("a", { "href": "http://localhost:8168/Account/AccountSignIn", "className": "btn btn-primary btn-lg" }, "Play Go")),
       );
    }
}

