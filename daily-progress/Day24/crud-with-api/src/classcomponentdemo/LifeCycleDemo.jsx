import React, { Component } from "react";

class LifeCycleDemo extends Component {
  constructor(props) {
    super(props);
    this.state = { count: 0 };
    console.log("Constructor Called");
  }

  componentDidMount() {
    console.log("ComponentDidMount - Component Mounted");
  }

  componentDidUpdate() {
    console.log("ComponentDidUpdate - Component Updated");
  }

  componentWillUnmount() {
    console.log("ComponentWillUnmount - Component Will Unmount");
  }

  increment = () => {
    this.setState({ count: this.state.count + 1 });
  };

  render() {
    console.log("Render Called");
    return (
      <>
        <h2>Class Component LifeCycle Methods Demo</h2>
        <h3>Count: {this.state.count}</h3>
        <button onClick={this.increment}>Increment</button>
      </>
    );
  }
}

export default LifeCycleDemo;
