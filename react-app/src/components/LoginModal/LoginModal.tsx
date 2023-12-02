import { Formik, Form, Field, ErrorMessage } from "formik";
import { useNavigate } from "react-router-dom";
import * as Yup from "yup";
import React from "react";

import { LoginInterface } from "../../interfaces/LoginInterface";

import "./LoginPage.css";

const validationSchema = Yup.object({
  email: Yup.string().required("Please enter an email"),
  password: Yup.string().required("Please enter a password"),
});

const LoginModal: React.FC<{ onClose: () => void }> = ({ onClose }) => {
  const navigate = useNavigate();

  const initialValues: LoginInterface = {
    email: "",
    password: "",
  };

  const handleSubmit = async (values: LoginInterface) => {
    try {
      onClose();
      navigate("/");
    } catch (error) {
      console.log(error);
    }
  };

  const handleCancel = () => {
    onClose();
  };

  return (
    <div className="login-modal">
      <div className="login-content">
        <Formik
          initialValues={initialValues}
          validationSchema={validationSchema}
          onSubmit={handleSubmit}
        >
          {({ isValid, dirty }) => (
            <Form className="form">
              <div className="form-group">
                <label className="form-label" htmlFor="email">
                  Email:
                </label>
                <Field
                  className="form-input"
                  type="text"
                  id="email"
                  name="email"
                />
                <ErrorMessage
                  className="form-error"
                  name="email"
                  component="div"
                />
              </div>
              <div className="form-group">
                <label className="form-label" htmlFor="email">
                  Password:
                </label>
                <Field
                  className="form-input"
                  type="password"
                  id="password"
                  name="password"
                />
                <ErrorMessage
                  className="form-error"
                  name="password"
                  component="div"
                />
              </div>
              <div className="form-buttons">
                <button
                  className="form-submit"
                  type="submit"
                  disabled={!isValid || !dirty}
                >
                  Submit
                </button>
                <button
                  className="form-cancel"
                  type="button"
                  onClick={handleCancel}
                >
                  Cancel
                </button>
              </div>
            </Form>
          )}
        </Formik>
      </div>
    </div>
  );
};

export default LoginModal;
