import { render, screen, fireEvent } from "@testing-library/react";

import React from "react";

import NotFoundPage from "./NotFoundPage";

jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useNavigate: () => jest.fn(),
}));

let mockNavigate = jest.fn();

describe("NotFoundPage Componente", () => {
  beforeEach(() => {
    mockNavigate = jest.fn();

    jest
      .spyOn(require("react-router-dom"), "useNavigate")
      .mockReturnValue(mockNavigate);
  });

  test("renders NotFoundPage correctly", () => {
    // Render
    render(<NotFoundPage />);

    // Assert
    expect(screen.getByTestId("error-code")).toBeInTheDocument();
    expect(screen.getByTestId("error-message")).toBeInTheDocument();
    expect(screen.getByTestId("error-detail")).toBeInTheDocument();
    expect(screen.getByTestId("redirect-button")).toBeInTheDocument();
  });

  test("navigates to home page on button click", () => {
    // Render
    render(<NotFoundPage />);

    // Act
    const redirectButton = screen.getByTestId("redirect-button");
    fireEvent.click(redirectButton);

    // Assert
    expect(mockNavigate).toHaveBeenCalledTimes(1);
    expect(mockNavigate).toHaveBeenCalledWith("/");
  });
});
