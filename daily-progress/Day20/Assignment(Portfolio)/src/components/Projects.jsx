import React from "react";

function Projects() {
  const projectList = [
    {
      id: 1,
      title: "Asset Management System",
      description:
        "Developed a full-stack asset tracking and service request management platform using ASP.NET Core, Entity Framework, and React. Has organizations to manage asset lifecycle, submit and track service requests, and streamline audits. Implemented role-based access control, responsive UI with Material UI, and optimized SQL queries for high performance. This solution significantly reduced manual tracking efforts and improved service handling efficiency.",
     image: "/project.jpg",
    },
    {
      id: 2,
      title: "Car Connect",
      description:
        "Built the backend system using C# and ASP.NET Core for a connected vehicle platform with role-based login for admins and users. Implemented APIs to handle vehicle bookings, tracked which user booked which vehicle for how many days, and added strict validations such as disallowing bookings for vehicles with future manufacturing dates. The system ensures secure access and accurate vehicle usage monitoring, ready for frontend integration.",
      image: "/car.jpg",
   },
    
  ];

  return (
    <section
      id="projects"
      className="py-5"
      style={{
        minHeight: "100vh",
        backgroundColor: "#f8f9fa",
        color: "#212529",
        scrollMarginTop: "75px",
      }}
    >
      <div className="container text-center">
        <h2 className="fs-2 fw-bold mb-4">My Projects</h2>

        <div className="row justify-content-center">
          {projectList.map((project) => (
            <div key={project.id} className="col-12 col-md-6 col-lg-4 mb-4">
              <div className="card shadow-sm h-100">
                {/* Image added here */}
                <img
                  src={project.image}
                  className="card-img-top"
                  alt={project.title}
                  style={{ height: "200px", objectFit: "cover" }}
                />
                <div className="card-body">
                  <h5 className="card-title fw-bold">{project.title}</h5>
                  <p className="card-text">{project.description}</p>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}

export default Projects;
