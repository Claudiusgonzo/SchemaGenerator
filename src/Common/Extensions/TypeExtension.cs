﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Common.Utilities;
using System;
using System.Reflection;

namespace Common.Extensions
{
    public static class MemberInfoExtension
    {
        /// <summary>
        /// Get the type of a <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="memberInfo">A <see cref="MemberInfo"/></param>
        /// <returns>The field type, property type or return type of <paramref name="memberInfo"/></returns>
        public static Type GetUnderlyingType(this MemberInfo memberInfo)
        {
            Ensure.NotNull(nameof(memberInfo), memberInfo);

            switch (memberInfo)
            {
                case FieldInfo fieldInfo:
                    return fieldInfo.FieldType;
                case MethodInfo methodInfo:
                    return methodInfo.ReturnType;
                case PropertyInfo propertyInfo:
                    return propertyInfo.PropertyType;
                default:
                    throw new UnexpectedException(nameof(MemberInfo), memberInfo.GetType().Name);
            }
        }
    }
}
