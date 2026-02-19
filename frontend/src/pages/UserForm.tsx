import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createUser, getUserById, updateUser } from "../services/UserService";
import type { UserCreateDto } from "../types/User";

const UserForm = () => {
  const navigate = useNavigate();
  const { id } = useParams();
  const [user, setUser] = useState<UserCreateDto>({
    firstName: "",
    lastName: "",
    email: "",
    role: "User",
  });
 const [loading, setLoading] = useState(false);
 const [error, setError] = useState<string | null>(null);
 const [success, setSuccess] = useState<string | null>(null);


  const isEditMode = Boolean(id);

  useEffect(() => {
  if (isEditMode && id) {
    const fetchUser = async () => {
      try {
        setLoading(true);
        const data = await getUserById(id);
        setUser({
          firstName: data.firstName,
          lastName: data.lastName,
          email: data.email,
          role: data.role,
        });
      } catch {
        setError("Failed to load user.");
      } finally {
        setLoading(false);
      }
    };

    fetchUser();
  }
 }, [id, isEditMode]);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  setError(null);
  setSuccess(null);

  try {
    setLoading(true);

    if (isEditMode && id) {
      await updateUser(id, user);
      setSuccess("User updated successfully!");
    } else {
      await createUser(user);
      setSuccess("User created successfully!");
    }

    setTimeout(() => navigate("/"), 1000);
    } catch {
        setError("Something went wrong. Please try again.");
    } finally {
        setLoading(false);
    }
    };


  return (
    <>
    {loading && <p>Loading...</p>}

    {error && (
    <div style={{ color: "red", marginBottom: "10px" }}>
        {error}
    </div>
    )}

    {success && (
    <div style={{ color: "green", marginBottom: "10px" }}>
        {success}
    </div>
    )}

    <form onSubmit={handleSubmit}>
      <h2>{isEditMode ? "Edit User" : "Create User"}</h2>
      <input
        name="firstName"
        placeholder="First Name"
        value={user.firstName}
        onChange={handleChange}
        required
      />
      <input
        name="lastName"
        placeholder="Last Name"
        value={user.lastName}
        onChange={handleChange}
        required
      />
      <input
        name="email"
        placeholder="Email"
        type="email"
        value={user.email}
        onChange={handleChange}
        required
      />
      <select name="role" value={user.role} onChange={handleChange}>
        <option value="User">User</option>
        <option value="Admin">Admin</option>
      </select>
      <button type="submit" disabled={loading}>
        {loading
            ? "Processing..."
            : isEditMode
            ? "Update"
            : "Save"}
      </button>

    </form>
    </>
  );
};

export default UserForm;
