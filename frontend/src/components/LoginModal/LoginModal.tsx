import { Formik, Form, Field, ErrorMessage } from "formik";
import { toast } from "react-toastify";
import * as Yup from "yup";
import React from "react";

import { LoginInterface } from "../../interfaces/LoginInterface";
import accountService from "../../services/AccountService";
import { useAuth } from "../../contexts/AuthContext";

import "./LoginModal.css";

const validationSchema = Yup.object({
  email: Yup.string().required("Please enter an email"),
  password: Yup.string().required("Please enter a password"),
});

const LoginModal: React.FC<{ onClose: () => void }> = ({ onClose }) => {
  const { login } = useAuth();

  const initialValues: LoginInterface = {
    email: "",
    password: "",
  };

  const handleSubmit = async (values: LoginInterface) => {
    try {
      const response = await accountService.login(values);
      login(response.token, response.user);
      onClose();
    } catch (error) {
      toast.error((error as Error).message as React.ReactNode);
    }
  };

  const handleCancel = () => {
    onClose();
  };

  return (
    <div className="login-modal">
      <div className="login-content">
        <div className="page-header">
          <p data-testid="page-title" className="page-header-title">
            Welcome Back!
          </p>
          <p data-testid="page-description" className="page-header-description">
            Log in to access exclusive features, create groups, join
            celebrations, and share special moments.
          </p>
        </div>
        <Formik
          initialValues={initialValues}
          validationSchema={validationSchema}
          onSubmit={handleSubmit}
        >
          {({ isValid, dirty }) => (
            <Form className="login-form">
              <div className="form-group">
                <label
                  data-testid="email-label"
                  className="form-label"
                  htmlFor="email"
                >
                  Email:
                </label>
                <Field
                  data-testid="email-input"
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
                <label
                  data-testid="password-label"
                  className="form-label"
                  htmlFor="password"
                >
                  Password:
                </label>
                <Field
                  data-testid="password-input"
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
                  data-testid="submit-button"
                  className="form-submit"
                  type="submit"
                  disabled={!isValid || !dirty}
                >
                  Login
                </button>
                <button
                  data-testid="cancel-button"
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
