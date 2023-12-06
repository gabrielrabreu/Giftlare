import { render, screen, fireEvent, waitFor } from "@testing-library/react";

import { act } from "react-dom/test-utils";
import React from "react";

import { mockAccountService } from "../../mocks/services/AccountService";
import LoginModal from "./LoginModal";

jest.mock("react-toastify", () => ({
  ...jest.requireActual("react-toastify"),
  toast: {
    error: jest.fn(),
  },
}));

jest.mock("../../contexts/AuthContext", () => ({
  ...jest.requireActual("../../contexts/AuthContext"),
  useAuth: () => jest.fn(),
}));

jest.mock("../../services/AccountService", () => ({
  __esModule: true,
  default: mockAccountService,
}));

let mockLogin = jest.fn();
let onClose = jest.fn();

describe("LoginModal", () => {
  beforeEach(() => {
    mockLogin = jest.fn();
    onClose = jest.fn();

    jest
      .spyOn(require("../../contexts/AuthContext"), "useAuth")
      .mockReturnValue({ login: mockLogin });
  });

  test("should render correctly", () => {
    // Render
    render(<LoginModal onClose={() => onClose()} />);

    // Assert
    expect(screen.getByTestId("page-title")).toBeInTheDocument();
    expect(screen.getByTestId("page-description")).toBeInTheDocument();
    expect(screen.getByTestId("email-label")).toBeInTheDocument();
    expect(screen.getByTestId("email-input")).toBeInTheDocument();
    expect(screen.getByTestId("password-label")).toBeInTheDocument();
    expect(screen.getByTestId("password-input")).toBeInTheDocument();
    expect(screen.getByTestId("submit-button")).toBeInTheDocument();
    expect(screen.getByTestId("cancel-button")).toBeInTheDocument();
  });

  test("should handle form submission successfully", async () => {
    // Arrange
    const mockLoginResponse = {
      token: "token",
      user: {
        id: "user id",
        name: "user name",
        email: "user email",
        language: "user language",
      },
    };
    mockAccountService.login.mockResolvedValue(mockLoginResponse);

    const userEmail = "Test Email";
    const userPassword = "Test Password";

    // Render
    render(<LoginModal onClose={() => onClose()} />);

    // Act
    await act(async () => {
      fireEvent.change(screen.getByTestId("email-input"), {
        target: { value: userEmail },
      });
      fireEvent.change(screen.getByTestId("password-input"), {
        target: { value: userPassword },
      });
      fireEvent.click(screen.getByTestId("submit-button"));
    });

    // Assert
    expect(mockAccountService.login).toHaveBeenCalledWith({
      email: userEmail,
      password: userPassword,
    });
    expect(mockLogin).toHaveBeenCalledWith(
      mockLoginResponse.token,
      mockLoginResponse.user,
    );
    expect(onClose).toHaveBeenCalled();
  });

  test("should toast error when service throw exception", async () => {
    // Arrange
    mockAccountService.login.mockRejectedValue(new Error("error"));

    // Render
    render(<LoginModal onClose={() => onClose()} />);

    // Act
    await act(async () => {
      fireEvent.change(screen.getByTestId("email-input"), {
        target: { value: "Test Email" },
      });
      fireEvent.change(screen.getByTestId("password-input"), {
        target: { value: "Test Password" },
      });
      fireEvent.click(screen.getByTestId("submit-button"));
    });

    // Assert
    await waitFor(() => {
      expect(require("react-toastify").toast.error).toHaveBeenCalledWith(
        "error",
      );
    });
  });

  test("should handle form cancellation", async () => {
    // Render
    render(<LoginModal onClose={() => onClose()} />);

    // Act
    fireEvent.click(screen.getByTestId("cancel-button"));

    // Assert
    expect(onClose).toHaveBeenCalledWith();
  });
});
