import { render, screen, fireEvent, waitFor } from "@testing-library/react";

import { act } from "react-dom/test-utils";
import React from "react";

import { mockGroupService } from "../../mocks/services/GroupService";
import CreateGroupPage from "./CreateGroupPage";

jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useNavigate: () => jest.fn(),
}));

jest.mock("react-toastify", () => ({
  ...jest.requireActual("react-toastify"),
  toast: {
    error: jest.fn(),
  },
}));

jest.mock("../../services/GroupService", () => ({
  __esModule: true,
  default: mockGroupService,
}));

describe("CreateGroupPage Componente", () => {
  test("should render correctly", () => {
    // Render
    render(<CreateGroupPage />);

    // Assert
    expect(screen.getByTestId("page-title")).toBeInTheDocument();
    expect(screen.getByTestId("page-description")).toBeInTheDocument();
    expect(screen.getByTestId("name-label")).toBeInTheDocument();
    expect(screen.getByTestId("name-input")).toBeInTheDocument();
    expect(screen.getByTestId("image-label")).toBeInTheDocument();
    expect(screen.getByTestId("image-input")).toBeInTheDocument();
    expect(screen.getByTestId("submit-button")).toBeInTheDocument();
    expect(screen.getByTestId("cancel-button")).toBeInTheDocument();
  });

  test("should handle form submission successfully", async () => {
    // Arrange
    const mockNavigate = jest.fn();
    jest
      .spyOn(require("react-router-dom"), "useNavigate")
      .mockReturnValue(mockNavigate);

    const groupName = "Test Group";
    const groupImage = "Test Group Image";

    // Render
    render(<CreateGroupPage />);

    // Act
    await act(async () => {
      fireEvent.change(screen.getByTestId("name-input"), {
        target: { value: groupName },
      });
      fireEvent.change(screen.getByTestId("image-input"), {
        target: { value: groupImage },
      });
      fireEvent.click(screen.getByTestId("submit-button"));
    });

    // Assert
    expect(mockGroupService.create).toHaveBeenCalledWith({
      name: groupName,
      image: groupImage,
    });
    expect(mockNavigate).toHaveBeenCalledWith("/view-group/0");
  });

  test("should toast error when service throw exception", async () => {
    // Arrange
    mockGroupService.create.mockRejectedValue(new Error("error"));

    // Render
    render(<CreateGroupPage />);

    // Act
    await act(async () => {
      fireEvent.change(screen.getByTestId("name-input"), {
        target: { value: "Test Group" },
      });
      fireEvent.change(screen.getByTestId("image-input"), {
        target: { value: "Test Group Image" },
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
    // Arrange
    const mockNavigate = jest.fn();
    jest
      .spyOn(require("react-router-dom"), "useNavigate")
      .mockReturnValue(mockNavigate);

    // Render
    render(<CreateGroupPage />);

    // Act
    fireEvent.click(screen.getByTestId("cancel-button"));

    // Assert
    expect(mockNavigate).toHaveBeenCalledWith("/list-groups");
  });
});
