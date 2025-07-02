import React from "react";

function Navbar() {
  return (
    <nav
      className="navbar navbar-expand-md navbar-dark bg-black fixed-top"
      style={{ minHeight: "70px" }}
    >
      <div className="container-fluid d-flex justify-content-between align-items-center">
        <h1 className="navbar-brand mb-0" style={{ fontSize: "1.75rem" }}>
          Nithyasri D P
        </h1>
        <ul className="navbar-nav d-flex flex-row gap-4 me-3">
          <li className="nav-item">
            <a className="nav-link text-white" href="#home">Home</a>
          </li>
          <li className="nav-item">
            <a className="nav-link text-white" href="#about">About</a>
          </li>
          <li className="nav-item">
            <a className="nav-link text-white" href="#projects">Projects</a>
          </li>
          <li className="nav-item">
            <a className="nav-link text-white" href="#contact">Contact</a>
          </li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;
