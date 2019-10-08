﻿using System;
using System.Collections.Generic;

namespace ReactViewControl {

    public abstract class ViewModuleContainer : IViewModule {

        private IExecutionEngine engine;

        protected virtual string JavascriptSource => null;
        protected virtual string NativeObjectName => null;
        protected virtual string ModuleName => null;
        protected virtual string Source => null;

        protected virtual object CreateNativeObject() => null;

        protected virtual string[] Events => new string[0];

        protected virtual KeyValuePair<string, object>[] PropertiesValues => new KeyValuePair<string, object>[0];

        string IViewModule.JavascriptSource => JavascriptSource;

        string IViewModule.NativeObjectName => NativeObjectName;

        string IViewModule.Name => ModuleName;

        string IViewModule.Source => Source;

        object IViewModule.CreateNativeObject() => CreateNativeObject();

        string[] IViewModule.Events => Events;

        KeyValuePair<string, object>[] IViewModule.PropertiesValues => PropertiesValues;

        void IViewModule.Bind(IExecutionEngine engine) => this.engine = engine;

        IExecutionEngine IViewModule.Engine => ExecutionEngine;

        // ease access in generated code
        protected IExecutionEngine ExecutionEngine {
            get {
                if (engine == null) {
                    throw new InvalidOperationException("View module must be bound to an execution engine ");
                }
                return engine;
            }
        }
    }
}
