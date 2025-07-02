import React from "react";

function About() {
  const educationList = [
    {
      id: 1,
      degree: "B.E. Computer Science and Engineering",
      institution: "Vivekanandha College of Engineering for Women",
      year: "2021 - 2025",
    },
    {
      id: 2,
      degree: "HSC (12th Standard)",
      institution: "Bharathiyar Higher Secondary School",
      year: "2020 - 2021",
    },
    {
      id: 3,
      degree: "SSLC (10th Standard)",
      institution: "Rasi Matriculation Higher Secondary School",
      year: "2018 - 2019",
    },
  ];

  return (
    <section
      id="about"
      className="py-5"
      style={{
        minHeight: "100vh",
        backgroundColor: "#e9ecef",
        color: "#212529",
        scrollMarginTop: "73px",
      }}
    >
      <div className="container text-center">
        <h2 className="fs-2 fw-bold mb-4">About Me</h2>

        <p className="fs-5">
          I'm a Full Stack Developer specializing in C#, .NET, and React, with experience building robust web applications from front to back. On the backend, I work with ASP.NET Core, Entity Framework, and REST APIs to create secure, efficient services. On the frontend, I use React and modern UI libraries to deliver clean, responsive interfaces.
        </p>

        <h3 className="fs-4 fw-bold mt-5 mb-3">Educational Background</h3>

        <div className="row justify-content-center">
          {educationList.map((edu) => (
            <div key={edu.id} className="col-12 col-md-6 col-lg-4 mb-4">
              <div className="card shadow-sm h-100">
                <div className="card-body">
                  <h5 className="card-title fw-bold">{edu.degree}</h5>
                  <p className="card-text">{edu.institution}</p>
                  <p className="card-text text-muted">{edu.year}</p>
                </div>
              </div>
            </div>
          ))}
        </div>

        {/* ➕ Social Links (Buttons) */}
        <div className="mt-4 d-flex justify-content-center gap-3 flex-wrap">
          <a
            href="https://www.linkedin.com/in/nithyasri-dp-610b7a21b"
            target="_blank"
            rel="noopener noreferrer"
            className="btn btn-outline-dark"
          >
            🔗 LinkedIn
          </a>
          <a
            href="https://github.com/Nithyasri-DP"
            target="_blank"
            rel="noopener noreferrer"
            className="btn btn-outline-dark"
          >
            💻 GitHub
          </a>
        </div>
      </div>
    </section>
  );
}

export default About;
