import React, { useEffect, useState } from "react";

export default function LifecycleFunctional() {
  const [count, setCount] = useState(0);

  useEffect(() => {
    console.log("useEffect (componentDidMount)");
   
    return () => {
      console.log("Cleanup (componentWillUnmount)");
    };
  }, []); 

  useEffect(() => {
    if (count !== 0) {
      console.log("useEffect (componentDidUpdate) - Count changed");
    }
  }, [count]); 

  return (
    <>
      <h2>Functional Component Lifecycle Demo</h2>
      <h3>Count: {count}</h3>
      <button onClick={() => setCount(count + 1)}>Increment</button>
    </>
  );
}
