﻿// <copyright file="User.cs" company="Yeti Softworks LLC">
// Copyright (c) Yeti Softworks LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace MeshyDB.SDK.Models
{
    /// <summary>
    /// Class that defines a user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the id of the user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is verified.
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the roles assigned.
        /// </summary>
        public IEnumerable<UserRole> Roles { get; set; }

        /// <summary>
        /// Gets or sets the security questions for user.
        /// </summary>
        public IEnumerable<SecurityQuestionHash> SecurityQuestions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a user is anonymous.
        /// </summary>
        public bool Anonymous { get; set; }

        /// <summary>
        /// Gets or sets when a user last accessed the system.
        /// </summary>
        public DateTimeOffset? LastAccessed { get; set; }
    }
}
