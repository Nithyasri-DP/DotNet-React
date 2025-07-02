import React from "react";

function Home() {
  return (
    <div>
      <header>
        <h1>Welcome to Home page</h1>
      </header>

      <nav>
        <ul>
          <li>
            <a href="/home"> 🏡Home</a>
          </li>
          <li>
            <a href="/about">🗒️About</a>
          </li>
          <li>
            <a href="/services">⚓Services</a>
          </li>
          <li>
            <a href="/contact">📞Contact</a>
          </li>
        </ul>
      </nav>
    </div>
  );
}

export default Home;
