import React from "react";

function Footer() {
  return (
    <footer
      className="bg-black text-white text-center py-3"
      style={{ marginTop: "auto" }}
    >
      <p className="mb-0">
        © {new Date().getFullYear()} Nithya. All rights reserved.
      </p>
    </footer>
  );
}

export default Footer;
