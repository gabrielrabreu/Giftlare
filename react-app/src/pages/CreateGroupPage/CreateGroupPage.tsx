import { Formik, Form, Field, ErrorMessage } from "formik";
import { useNavigate } from "react-router-dom";
import * as Yup from "yup";
import React from "react";

import { CreateGroupInterface } from "../../interfaces/CreateGroupInterface";

import "./CreateGroupPage.css";

const validationSchema = Yup.object({
  name: Yup.string().required("Please enter a name"),
});

const CreateGroupPage: React.FC = () => {
  const navigate = useNavigate();

  const initialValues: CreateGroupInterface = {
    name: "",
  };

  const handleSubmit = async (values: CreateGroupInterface) => {
    try {
      navigate("/view-group/0");
    } catch (error) {
      console.log(error);
    }
  };

  const handleCancel = () => {
    navigate("/list-groups");
  };

  return (
    <div className="page-container">
      <div className="page-content">
        <div className="page-header">
          <p className="page-header-title">Create a Group</p>
          <p className="page-header-description">The page description</p>
        </div>
        <Formik
          initialValues={initialValues}
          validationSchema={validationSchema}
          onSubmit={handleSubmit}
        >
          {({ isValid, dirty }) => (
            <Form className="form">
              <div className="form-group">
                <label className="form-label" htmlFor="name">
                  Name:
                </label>
                <Field
                  className="form-input"
                  type="text"
                  id="name"
                  name="name"
                />
                <ErrorMessage
                  className="form-error"
                  name="name"
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

export default CreateGroupPage;
