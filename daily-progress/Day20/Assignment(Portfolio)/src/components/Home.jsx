import React from "react";

function Home() {
  return (
    <section
      id="home"
      className="d-flex align-items-center"
      style={{
        minHeight: "100vh",
        backgroundColor: "#f8f9fa",
        color: "#212529",
        paddingTop: "80px"
      }}
    >
      <div className="container text-center">
        <h1 className="fs-1 fw-bold">Hi, This is Nithyasri D P</h1>
        <p className="fs-5 mt-3">
          A Full Stack Developer skilled in React and .NET
        </p>

        <a
          href="/Nithya_resume.pdf"
          download
          className="btn btn-dark mt-3 me-2"
        >
          📄 Download CV
        </a>

        <div className="mt-4">
          <p className="fs-6 fw-medium mb-2">Want to know more about me?</p>
          <a href="#about" className="btn btn-outline-secondary">
            🔽 Explore Below
          </a>
        </div>
      </div>
    </section>
  );
}

export default Home;
