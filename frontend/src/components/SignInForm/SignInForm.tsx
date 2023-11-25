import { faEnvelope, faLock } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import { Formik, Form, Field, ErrorMessage } from "formik";
import { Navigate } from "react-router-dom";
import { toast } from "react-toastify";
import * as Yup from "yup";

import accountService from "../../services/AccountService";
import { SignInDto } from "../../interfaces/SignInDto";
import { useAuth } from "../../contexts/AuthContext";
import { translate } from "../../translate";

import "./SignInForm.css";

const signInSchema = Yup.object().shape({
  email: Yup.string().email("Email inválido").required("Campo obrigatório"),
  password: Yup.string().required("Campo obrigatório"),
});

const SignInForm: React.FC = () => {
  const { signIn } = useAuth();

  const onSubmit = async (values: SignInDto) => {
    try {
      const response = await accountService.signIn(values);
      signIn(response.token, response.user);
      return <Navigate to="/home" />;
    } catch (error) {
      let errorMessage = error;
      if (error instanceof Error) {
        errorMessage = error.message;
      }
      toast.error(errorMessage as React.ReactNode);
    }
  };

  const initialValues: SignInDto = {
    email: "",
    password: "",
  };

  return (
    <Formik
      initialValues={initialValues}
      validationSchema={signInSchema}
      onSubmit={onSubmit}
    >
      {({ isValid, dirty }) => (
        <Form className="signin-form">
          <div className="form-field">
            <div className="label-container">
              <label htmlFor="email" className="label">
                {translate("signin.labels.email")}
              </label>
            </div>
            <div className="input-container">
              <FontAwesomeIcon icon={faEnvelope} className="icon" />
              <Field type="text" id="email" name="email" />
            </div>
            <ErrorMessage name="email" component="div"></ErrorMessage>
          </div>
          <div className="form-field">
            <div className="label-container">
              <label htmlFor="password" className="label">
                {translate("signin.labels.password")}
              </label>
            </div>
            <div className="input-container">
              <FontAwesomeIcon icon={faLock} className="icon" />
              <Field type="password" id="password" name="password" />
            </div>
            <ErrorMessage name="password" component="div"></ErrorMessage>
          </div>
          <div className="button-container">
            <button type="submit" disabled={!isValid || !dirty}>
              {translate("signin.buttons.submit")}
            </button>
          </div>
        </Form>
      )}
    </Formik>
  );
};

export default SignInForm;
