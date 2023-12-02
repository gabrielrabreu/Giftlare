import { Formik, Form, Field, ErrorMessage } from "formik";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import * as Yup from "yup";
import React from "react";

import { CreateGroupInterface } from "../../interfaces/CreateGroupInterface";
import groupService from "../../services/GroupService";

const validationSchema = Yup.object({
  name: Yup.string().required("Please enter a name"),
  image: Yup.string().required("Please enter an image"),
});

const CreateGroupPage: React.FC = () => {
  const navigate = useNavigate();

  const initialValues: CreateGroupInterface = {
    name: "",
    image: "",
  };

  const handleSubmit = async (values: CreateGroupInterface) => {
    try {
      await groupService.create(values);
      navigate("/view-group/0");
    } catch (error) {
      let errorMessage = error instanceof Error ? error.message : error;
      toast.error(errorMessage as React.ReactNode);
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
              <div className="form-group">
                <label className="form-label" htmlFor="image">
                  Image:
                </label>
                <Field
                  className="form-input"
                  type="text"
                  id="image"
                  name="image"
                />
                <ErrorMessage
                  className="form-error"
                  name="image"
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
