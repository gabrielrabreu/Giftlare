import SignInForm from "../../components/SignInForm/SignInForm";

import "./SignInPage.css";

const SignInPage: React.FC = () => {
  return (
    <div className="sign-in-page">
      <div className="card-container">
        <div className="form-container">
          <SignInForm />
        </div>
      </div>
    </div>
  );
};

export default SignInPage;
