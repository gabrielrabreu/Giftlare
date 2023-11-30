import "./HomePage.css";

const HomePage: React.FC = () => {
  return (
    <div className="home-page">
      <div className="principal-section">
        <div className="overlay"></div>
        <div className="section-text">
          <h1 className="section-title">
            Experience the Joy of Gifting with Santa Secrets
          </h1>
          <p className="section-description">Join us this Christmas</p>
        </div>
      </div>
      <div className="image-section">
        <div className="text-column">
          <div className="section-text">
            <h2 className="section-title">
              Connect with Loved Ones in Festive Groups
            </h2>
            <p className="section-description">
              This Christmas, spread the holiday joy further with Santa Secrets.
              Join or create groups with your loved ones and discover the fun of
              festive gifting. Allow the spirit of giving to bring you closer.
            </p>
            <button className="green-button">
              <span className="button-text">Join a Group Now</span>
            </button>
          </div>
        </div>
        <div className="image-column align-right">
          <img
            src="mifcypa0yqslostibhfx.jpg"
            alt="Imagem da segunda seção"
            className="section-image"
          />
        </div>
      </div>
      <div className="image-section">
        <div className="image-column align-left">
          <img
            src="demmqv130xrtnxb7l0qa.jpg"
            alt="Imagem da segunda seção"
            className="section-image"
          />
        </div>
        <div className="text-column">
          <div className="section-text">
            <h2 className="section-title">
              Create Your Own Festive Group Today
            </h2>
            <p className="section-description">
              With Santa Secrets, you are not just a part of the festive joy,
              you create it. Develop your own group, invite friends and see the
              joy multiply. Unwrap happiness today.
            </p>
            <button className="green-button">
              <span className="button-text">Create Group Now</span>
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
