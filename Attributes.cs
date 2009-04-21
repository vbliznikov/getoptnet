﻿/*
 * Copyright (c) 2009 Nils Maier
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */

using System;

namespace NMaier.GetOptNet
{
    public enum ArgumentCollision
    {
        Overwrite,
        Ignore,
        Throw
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class Argument : Attribute
    {
        private string arg = "";
        private string helptext = "";
        private string helpvar = "";
        private ArgumentCollision collision = ArgumentCollision.Ignore;


        public Argument() { }
        public Argument(string aArg) { arg = aArg; }
        public string GetArg() { return arg; }
        public string Helptext
        {
            get { return helptext; }
            set { helptext = value; }
        }
        public string Helpvar
        {
            get { return helpvar; }
            set { helpvar = value; }
        }
        public ArgumentCollision OnCollision
        {
            get { return collision; }
            set { collision = value; }
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ShortArgument : Attribute
    {
        private char arg;
        public ShortArgument(char aArg) { arg = aArg; }
        public char GetArg() { return arg; }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class ArgumentAlias : Attribute
    {
        private string alias;
        public ArgumentAlias(string aAlias) { alias = aAlias; }
        public string GetAlias() { return alias; }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class ShortArgumentAlias : Attribute
    {
        private char alias;
        public ShortArgumentAlias(char aAlias) { alias = aAlias; }
        public char GetAlias() { return alias; }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class Counted : Attribute { }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class Parameters : Attribute { }


    [FlagsAttribute]
    public enum ArgumentPrefixType : ushort
    {
        None = 0,
        Dashes = 1,
        Slashes = 2,
        Both = 3
    }

    public enum UnknownArgumentsAction
    {
        IGNORE,
        THROW
    }

    public enum UsageAliasShowOption
    {
        SHOW,
        HIDE
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GetOptOptions : Attribute
    {
        private ArgumentPrefixType apt = ArgumentPrefixType.Both;
        private ArgumentPrefixType upt = ArgumentPrefixType.Dashes;
        private UnknownArgumentsAction uaa = UnknownArgumentsAction.IGNORE;
        private UsageAliasShowOption aso = UsageAliasShowOption.HIDE;

        private string usageIntro = "Usage:";
        private string usageEpilog = "";

        public GetOptOptions() { }
        public ArgumentPrefixType AcceptPrefix
        {
            get { return apt; }
            set { apt = value; }
        }
        public UnknownArgumentsAction OnUnknownArgument
        {
            get { return uaa; }
            set { uaa = value; }
        }
        public UsageAliasShowOption UsageShowAliases
        {
            get { return aso; }
            set { aso = value; }
        }
        public ArgumentPrefixType UsagePrefix
        {
            get { return upt; }
            set
            {
                if (value != ArgumentPrefixType.Dashes && value != ArgumentPrefixType.Slashes)
                {
                    throw new ProgrammingError("UsagePrefix must be Dashes or Slashes");
                }
                upt = value;
            }
        }

        public string UsageIntro
        {
            get { return usageIntro; }
            set { usageIntro = value; }
        }
        public string UsageEpilog
        {
            get { return usageEpilog; }
            set { usageEpilog = value; }
        }
    }
}