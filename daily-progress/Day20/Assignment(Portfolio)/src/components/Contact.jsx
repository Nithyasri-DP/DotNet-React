import React, { useState } from "react";

function Contact() {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    message: "",
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    const { id, value } = e.target;
    setFormData({ ...formData, [id]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const newErrors = {};

    if (!/^[a-zA-Z\s]+$/.test(formData.name.trim())) {
      newErrors.name = "Name must contain only letters and spaces.";
    }

    if (!/^\S+@\S+\.\S+$/.test(formData.email.trim())) {
      newErrors.email = "Please enter a valid email address.";
    }

    if (formData.message.trim() === "") {
      newErrors.message = "Message cannot be empty.";
    }

    setErrors(newErrors);

    if (Object.keys(newErrors).length === 0) {
      alert("Message submitted successfully!");
      setFormData({ name: "", email: "", message: "" });
    }
  };

  return (
    <section
      id="contact"
      className="py-5"
      style={{
        backgroundColor: "#e9ecef",
        color: "#212529",
        scrollMarginTop: "50px",
      }}
    >
      <div className="container">
        <h2 className="fs-2 fw-bold text-center mb-4">Contact Me</h2>

        <p className="text-center fs-5 mb-4">
          Feel free to reach out by filling the form below
        </p>

        <div className="row justify-content-center">
          <div className="col-12 col-md-8 col-lg-6">
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <label htmlFor="name" className="form-label fw-semibold">
                  Name
                </label>
                <input
                  type="text"
                  id="name"
                  className="form-control"
                  placeholder="Enter your name"
                  value={formData.name}
                  onChange={handleChange}
                  required
                />
                {errors.name && <small className="text-danger">{errors.name}</small>}
              </div>

              <div className="mb-3">
                <label htmlFor="email" className="form-label fw-semibold">
                  Email
                </label>
                <input
                  type="email"
                  id="email"
                  className="form-control"
                  placeholder="Enter your email"
                  value={formData.email}
                  onChange={handleChange}
                  required
                />
                {errors.email && <small className="text-danger">{errors.email}</small>}
              </div>

              <div className="mb-3">
                <label htmlFor="message" className="form-label fw-semibold">
                  Message
                </label>
                <textarea
                  id="message"
                  className="form-control"
                  rows="5"
                  placeholder="Write your message"
                  value={formData.message}
                  onChange={handleChange}
                  required
                ></textarea>
                {errors.message && <small className="text-danger">{errors.message}</small>}
              </div>

              <div className="text-center">
                <button type="submit" className="btn btn-dark px-4">
                  Submit
                </button>
              </div>
            </form>

            <div className="text-center mt-4">
              <p>📧 dpnithyasri75@gmail.com</p>
              <p>📞 +91 98765 43210</p>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}

export default Contact;
