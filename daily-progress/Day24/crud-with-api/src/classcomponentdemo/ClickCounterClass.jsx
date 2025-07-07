import React, { Component } from "react";

class ClickCounterClass extends Component {
  constructor(props) {
    super(props);

    this.state = {
      name: "Nithya",
      total: 0,
    };

    console.log("Constructor called");
  }

  handleClick = () => {
    this.setState({ total: this.state.total + 1 });
  };

   render() {
    console.log("Render called");

    return (
      <div style={{ textAlign: "center", marginTop: "40px" }}>
        <h1>Hello, {this.state.name}!</h1>
        <p>You clicked: {this.state.total} times</p>
        <button onClick={this.handleClick}>Click Me</button>
      </div>
    );
  }
}

export default ClickCounterClass;
